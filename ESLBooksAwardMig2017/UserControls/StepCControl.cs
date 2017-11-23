using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ESLBooksAwardMig2017.UserControls
{
    public partial class StepCControl : UserControl
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public StepCControl()
        {
            InitializeComponent();
        }

        #region Biz

        /// <summary>
        /// meta class
        /// </summary>
        protected class BookAtom
        {
            public string id;
            public string title;
            public string note;
        }

        /// <summary>
        /// meta class
        /// </summary>
        protected class BookBlogFirstLastUid
        {
            /// <summary>
            /// 大分類
            /// </summary>
            public string PrimaryClass;

            /// <summary>
            /// 第一筆的「獨立編號」
            /// </summary>
            public string FirstUid;

            /// <summary>
            /// 最末筆「獨立編號」
            /// </summary>
            public string LastIUid;
        }

        /// <summary>
        /// 將五大落書資料轉出 json 檔
        /// </summary>
        protected void OutputBooksBlogAsJson(BookAtom[] booksBlog, FileInfo fiJson)
        {
            if (fiJson.Exists) fiJson.Delete();

            using (StreamWriter sw = new StreamWriter(fiJson.OpenWrite(), Encoding.UTF8))
            {
                // header
                sw.WriteLine("[");

                // 
                int i;
                int len2 = booksBlog.Length - 1;
                for (i = 0; i < len2; i++)
                {
                    sw.WriteLine("{");
                    sw.WriteLine(string.Format("  \"id\":\"{0}\"", booksBlog[i].id));
                    sw.WriteLine(string.Format("  \"title\":\"{0}\"", booksBlog[i].title));
                    sw.WriteLine(string.Format("  \"note\":\"{0}\"", booksBlog[i].note));
                    sw.WriteLine("},");
                }

                // last row
                sw.WriteLine("{");
                sw.WriteLine(string.Format("  \"id\":\"{0}\"", booksBlog[i].id));
                sw.WriteLine(string.Format("  \"title\":\"{0}\"", booksBlog[i].title));
                sw.WriteLine(string.Format("  \"note\":\"{0}\"", booksBlog[i].note));
                sw.WriteLine("}");

                // tail
                sw.WriteLine("]"); 
            }
        }

        protected void DoGenerateLeftHtml(BOOKLIST info, FileInfo fiLeft)
        {
            if (fiLeft.Exists) fiLeft.Delete();

            using (StreamWriter sw = new StreamWriter(fiLeft.OpenWrite(), Encoding.UTF8))
            {
                // <!--[#獨立編號#]-->
                sw.WriteLine("<!--{0}-->", info.獨立編號);

                sw.WriteLine("<div class=\"popBook\">");
                sw.WriteLine("<div class=\"leftContent\">");

                //<h2>[#推薦作者#]</h2>
                sw.WriteLine("<h2>{0}</h2>", info.推薦作者);

                // <div class="bookimg"><img src="[#獨立編號#]/03.jpg" alt="" style="max-width:190px;max-heigth:270px;" /></div>
                sw.WriteLine("<div class=\"bookimg\"><img src=\"{0}/03.jpg\" alt=\"\" style=\"max-width:190px;max-heigth:270px;\" /></div>"
                    , info.獨立編號);

                // <h3>[#推薦書籍#]</h3>
                sw.WriteLine("<h3>{0}</h3>"
                    , info.推薦書籍);

                sw.WriteLine("</div>");
                sw.WriteLine("<div class=\"backBtn\"><a style=\"cursor: pointer\" onClick=\"parent.$.fn.colorbox.close(); \"></a></div>");

                //< div class="voteBtn"><a href = "../../[#VOTE_PAGE(大分類)#]?cb=[#大分類#]&cm=[#中分類#]&sid=[#獨立編號#]#anchor1" target="_blank"></a></div>
                sw.WriteLine("<div class=\"voteBtn\"><a href = \"../../{0}?cb={1}&cm={2}&sid={3}#anchor1\" target=\"_blank\"></a></div>"
                    , DetermineVotePage(info.大分類)
                    , info.大分類
                    , info.中分類
                    , info.獨立編號);

                //<div class="infoBtn"><a href = "http://www.eslite.com/product.aspx?pgid=[#ProductGuid#]&utm_source=eslite&utm_medium=eslite&utm_campaign=161019_award_p2" target="_blank"></a></div>
                sw.WriteLine("<div class=\"infoBtn\"><a href = \"http://www.eslite.com/product.aspx?pgid={0}&utm_source=eslite&utm_medium=eslite&utm_campaign=161019_award_p2\" target=\"_blank\"></a></div>"
                    , info.ProductGuid);

                sw.WriteLine("</div>");

                _logger.Info("產生 left.html of {0}: {1}", info.獨立編號, fiLeft.FullName);
            }

        }

        protected void DoGenerateRightHtml(BOOKLIST info, FileInfo fiRight, BookBlogFirstLastUid firstLastUid)
        {
            if (fiRight.Exists) fiRight.Delete();

            using (StreamWriter sw = new StreamWriter(fiRight.OpenWrite(), Encoding.UTF8))
            {
                // <!--[#獨立編號#]-->
                sw.WriteLine("<!--{0}-->", info.獨立編號);
                
                sw.WriteLine("<div class=\"popBook\">");

                //<div class="prev"><a href="../../book_want.aspx?sid=[#獨立編號-1#]" target="_blank"></a></div>
                if(info.獨立編號 != firstLastUid.FirstUid) // 不是第一筆
                {
                    sw.WriteLine("<div class=\"prev\"><a href=\"../../{0}?sid={1}{2:000}\" target=\"_blank\"></a></div>"
                        , DetermineWantPage(info.大分類)
                        , info.大分類
                        , info.順序 - 1);
                }

                //<div class="next"><a href="../../book_want.aspx?sid=[#獨立編號+1#]" target="_blank"></a></div>
                if (info.獨立編號 != firstLastUid.LastIUid) // 不是最末筆
                {
                    sw.WriteLine("<div class=\"next\"><a href=\"../../{0}?sid={1}{2:000}\" target=\"_blank\"></a></div>"
                        , DetermineWantPage(info.大分類)
                        , info.大分類
                        , info.順序 + 1);
                }

                sw.WriteLine("<div class=\"rightContent\">");

                //<% WHEN[#屬性#] == "總編|兩者" %>
                //<div class="titleBar"><h1><img src="../img/book_title01.png" width="150" height="44" alt=""/></h1></div>
                //<h2>[#推薦單位#] / [#推薦總編#] [#職銜#]</h2>
                //<p>[#總編推薦文#]</p>
                if(info.屬性 == "總編" || info.屬性 == "兩者")
                {
                    sw.WriteLine("<div class=\"titleBar\"><h1><img src=\"../img/book_title01.png\" width=\"150\" height=\"44\" alt=\"\"/></h1></div>");
                    sw.WriteLine("<h2>{0} / {1} {2}</h2>", info.推薦單位, info.推薦總編, info.職銜);
                    sw.WriteLine("<p>{0}</p>", info.總編推薦文);
                }

                // <% WHEN [#屬性#] == "職人|兩者" %>
                //<div class="titleBar2"><h1><img src="../img/book_title02.png" width="150" height="44" alt=""/></h1></div>
                //<h2>[#推薦職人店別#] / [#職人姓名#] </h2>
                //<p>[#職人推薦文#]</p>
                if (info.屬性 == "職人" || info.屬性 == "兩者")
                {
                    sw.WriteLine("<div class=\"titleBar2\"><h1><img src=\"../img/book_title02.png\" width=\"150\" height=\"44\" alt=\"\"/></h1></div>");
                    sw.WriteLine("<h2>{0} / {1}</h2>", info.推薦職人店別, info.職人姓名);
                    sw.WriteLine("<p>{0}</p>", info.職人推薦文);
                }

                sw.WriteLine("</div>");
                sw.WriteLine("</div>");

                _logger.Info("產生 right.html of {0}: {1}", info.獨立編號, fiRight.FullName);
            }
        }

        /// <summary>
        /// DetermineVotePage
        /// </summary>
        /// <param name="PrimaryClass">大分類</param>
        /// <remarks>
        /// [#VOTE_PAGE(大分類)#]
        /// a => "vote.aspx"
        /// b => "vote_pama.aspx"
        /// c => "vote_writer.aspx?"
        /// </remarks>
        protected string DetermineVotePage(string primaryClass)
        {
            switch(primaryClass)
            {
                case "a":
                    return "vote.aspx";
                case "b":
                    return "vote_pama.aspx";
                case "c":
                    return "vote_writer.aspx";
            }

            throw new ApplicationException(string.Format("未知的大分類{0}", primaryClass));
        }

        /// <summary>
        /// DetermineVotePage
        /// </summary>
        /// <param name="PrimaryClass">大分類</param>
        /// <remarks>
        /// [#WANT_PAGE(大分類)#]
        /// a => "book_want.aspx"
        /// b => "book_pama.aspx"
        /// c => "book_writer.aspx?"
        /// </remarks>
        protected string DetermineWantPage(string primaryClass)
        {
            switch (primaryClass)
            {
                case "a":
                    return "book_want.aspx";
                case "b":
                    return "book_pama.aspx";
                case "c":
                    return "book_writer.aspx";
            }

            throw new ApplicationException(string.Format("未知的大分類{0}", primaryClass));
        }

        #endregion

        private void txtTargetBaseFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtTargetBaseFolder.Text = dlg.SelectedPath;
            }
        }

        private void btnTransJson_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, () =>
            {
                // resource
                DirectoryInfo tgtFolder = new DirectoryInfo(txtTargetBaseFolder.Text);

                _logger.Info("# 開始產生json檔：");
                using (var ctx = new MetaDatabaseEntities())
                {
                    string[] bookBlogList = new string[5] { "book01", "book02", "book03", "book04", "book05" };
                    string[] jsonNameList = new string[5] { "books_01.json", "books_02.json", "books_03.json", "books_04.json", "books_05.json" };
                    int totalBooksCnt = 0;

                    for (int idx = 0; idx < 5; idx++)
                    {
                        string bookBlog = bookBlogList[idx];
                        string jsonName = jsonNameList[idx];

                        // query 五大落書
                        var qry = from c in ctx.BOOKLIST
                                  where c.書落 == bookBlog
                                  orderby c.順序
                                  select new BookAtom
                                  {
                                      id = c.獨立編號,
                                      title = "書本" + c.獨立編號,
                                      note = "簡介" + c.獨立編號
                                  };

                        BookAtom[] booksBlog = qry.ToArray();
                        _logger.Info("書落:{0} 筆數:{1}", bookBlog, booksBlog.Length);

                        // target folder & filepath
                        DirectoryInfo jsonTgtFolder = new DirectoryInfo(string.Format("{0}\\book\\js", tgtFolder.FullName));
                        if (!jsonTgtFolder.Exists) jsonTgtFolder.Create();
                        FileInfo jsonTgtFilepath = new FileInfo(jsonTgtFolder.FullName + "\\" + jsonName);

                        // save as json
                        OutputBooksBlogAsJson(booksBlog, jsonTgtFilepath);
                        _logger.Info("Output Json: {0}", jsonTgtFilepath.FullName);
                        totalBooksCnt += booksBlog.Length;
                    }

                    _logger.Info("處理 {0:N0} 筆", totalBooksCnt);
                }
            });
        }

        private void btnTransHtml_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, () =>
            {
                // resource
                DirectoryInfo tgtFolder = new DirectoryInfo(txtTargetBaseFolder.Text);

                // UI: show progress
                bool isTrial = chkTrial.Checked;
                int trialCount = (int)numTrialCount.Value;
                int counter = 0;

                using (var ctx = new MetaDatabaseEntities())
                {
                    // 取各大分類的 第一筆 與 最末筆 編號
                    var qryFirstLast = from c in ctx.BOOKLIST
                                       group c by c.大分類 into g
                                       select new BookBlogFirstLastUid
                                       {
                                           PrimaryClass = g.Key,
                                           FirstUid = g.Min(c => c.獨立編號),
                                           LastIUid = g.Max(c => c.獨立編號)
                                       };

                    var dict = qryFirstLast.ToDictionary(c => c.PrimaryClass);

                    // UI: show progress
                    prgBar.Value = 0;
                    prgBar.Maximum = isTrial ? trialCount : ctx.BOOKLIST.Count();

                    // GO
                    _logger.Info("# 開始產生html檔：");
                    foreach (var info in ctx.BOOKLIST)
                    {
                        // target folder & filepath
                        DirectoryInfo htmlTgtFolder = new DirectoryInfo(string.Format("{0}\\book\\{1}\\{2}\\", tgtFolder.FullName, info.書落, info.獨立編號));
                        if (!htmlTgtFolder.Exists) htmlTgtFolder.Create();

                        FileInfo fiLeft = new FileInfo(htmlTgtFolder.FullName + "\\left.html");
                        FileInfo fiRight = new FileInfo(htmlTgtFolder.FullName + "\\right.html");

                        DoGenerateLeftHtml(info, fiLeft);
                        //if (!fiLeft.Exists) throw new ApplicationException(string.Format("left.html產生失敗!目的檔不存在{0}。", fiLeft.FullName));

                        DoGenerateRightHtml(info, fiRight, dict[info.大分類]);
                        //if (!fiRight.Exists) throw new ApplicationException(string.Format("right.html產生失敗!目的檔不存在{0}。", fiRight.FullName));

                        // next
                        counter++;

                        // UI: show progress
                        lblStepMsg.Text = string.Format("項次:{0} {1}", info.項次, info.推薦書籍);
                        prgBar.PerformStep();

                        // 防止「沒有回應」
                        Application.DoEvents();

                        // trial
                        if (isTrial && counter >= trialCount)
                            break;
                    }

                    _logger.Info("處理 {0:N0} 筆", counter);
                }
            });
        }


    }


}

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
using OfficeOpenXml;

namespace ESLBooksAwardMig2017.UserControls
{
    public partial class StepAControl : UserControl
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public StepAControl()
        {
            InitializeComponent();
        }

        #region properties

        protected Form2 MainForm
        {
            get { return (Form2)this.ParentForm; }
        }

        #endregion

        #region Biz

        /// <summary>
        /// 匯入書單統整檔
        /// </summary>
        protected int DoImportBooklist(FileInfo fi, MetaDatabaseEntities ctx)
        {
            try
            {
                // resource
                ExcelPackage ep = new ExcelPackage(fi);
                ExcelWorksheet ws = ep.Workbook.Worksheets[1]; // sheet1

                // GO
                //using (var ctx = new MetaDatabaseEntities())
                using (var txn = ctx.Database.BeginTransaction())
                {
                    _logger.Info("清空資料...");
                    ctx.Database.ExecuteSqlCommand("DELETE FROM [BOOKLIST]");

                    _logger.Info("匯入資料...");
                    // data row, 取值, 1-base
                    for (int rowIdx = 2; rowIdx <= ws.Dimension.End.Row; rowIdx++)
                    {
                        BOOKLIST nr = new BOOKLIST();

                        nr.項次 = int.Parse(ws.Cells[rowIdx, 1].GetValue<string>());
                        nr.大分類 = ws.Cells[rowIdx, 2].GetValue<string>().Trim();
                        nr.中分類 = ws.Cells[rowIdx, 3].GetValue<string>().Trim();
                        nr.獨立編號 = ws.Cells[rowIdx, 4].GetValue<string>().Trim();
                        nr.圖檔名 = ws.Cells[rowIdx, 5].GetValue<string>().Trim();
                        nr.ProductGuid = ws.Cells[rowIdx, 6].GetValue<string>().Trim();
                        nr.順序 = int.Parse(ws.Cells[rowIdx, 7].GetValue<string>());
                        nr.屬性 = ws.Cells[rowIdx, 8].GetValue<string>().Trim();
                        nr.推薦書籍 = ws.Cells[rowIdx, 9].GetValue<string>().Trim();
                        nr.ISBN = ws.Cells[rowIdx, 10].GetValue<string>().Trim();
                        nr.MCH = ws.Cells[rowIdx, 11].GetValue<string>().Trim();
                        nr.分類 = ws.Cells[rowIdx, 12].GetValue<string>().Trim();
                        nr.出版日期 = ws.Cells[rowIdx, 13].GetValue<DateTime>();
                        nr.出版社 = ws.Cells[rowIdx, 14].GetValue<string>().Trim();
                        nr.推薦單位 = IsNull(ws.Cells[rowIdx, 15].GetValue<string>().Trim());
                        nr.推薦總編 = IsNull(ws.Cells[rowIdx, 16].GetValue<string>().Trim());
                        nr.職銜 = IsNull(ws.Cells[rowIdx, 17].GetValue<string>().Trim());
                        nr.總編推薦文 = IsNull(ws.Cells[rowIdx, 18].GetValue<string>().Trim());
                        nr.推薦職人店別 = IsNull(ws.Cells[rowIdx, 19].GetValue<string>().Trim());
                        nr.職人姓名 = IsNull(ws.Cells[rowIdx, 20].GetValue<string>().Trim());
                        nr.職人推薦文 = IsNull(ws.Cells[rowIdx, 21].GetValue<string>().Trim());
                        nr.推薦作者 = IsNull(ws.Cells[rowIdx, 22].GetValue<string>().Trim());
                        nr.Tag = ws.Cells[rowIdx, 23].GetValue<string>().Trim();

                        // 判斷
                        nr.書落 = DoDetermineBookBlog(nr.大分類, nr.中分類);

                        ctx.BOOKLIST.Add(nr);
                    }

                    ctx.SaveChanges();

                    // success
                    txn.Commit();

                    return ctx.BOOKLIST.Count();
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("DoImportBooklist fail. " + ex.Message, ex);
            }
        }

        /// <summary>
        /// 判斷五大落書
        /// </summary>
        /// <param name="primaryClass">大分類</param>
        /// <param name="secondaryClass">中分類</param>
        /// <remarks>
        /// 五大落書
        /// 第1落 book01: ac02, ac04
        /// 第2落 book02: b
        /// 第3落 book03: ac08, ac05
        /// 第4落 book04: c
        /// 第5落 book05: ac01, ac06, ac07, ac03
        /// </remarks>
        /// <returns></returns>
        protected string DoDetermineBookBlog(string primaryClass, string secondaryClass)
        {

            if (secondaryClass == "ac02" || secondaryClass == "ac04")
                return "book01";

            if (primaryClass == "b")
                return "book02";

            if (secondaryClass == "ac08" || secondaryClass == "ac05")
                return "book03";

            if (primaryClass == "c")
                return "book04";

            if (secondaryClass == "ac01" || secondaryClass == "ac06" || secondaryClass == "ac07" || secondaryClass == "ac03")
                return "book05";

            // otherwise
            return "unknow";
        }

        protected String IsNull(string str, string alternative = "")
        {
            return str == "NULL" ? alternative : str;
        }

        #endregion

        private void StepAControl_Load(object sender, EventArgs e)
        {
            // 設計模式中跳過邏輯運算。
            if (this.DesignMode) return;

            //# reload from MetaDatabase.mdf
            using (var ctx = new MetaDatabaseEntities())
            {
                bsBOOKLIST.DataSource = ctx.BOOKLIST.ToArray();
                this.MainForm.UpdateStatusLabel1(string.Format("筆數：{0:N0}", ctx.BOOKLIST.Count()));
            }
        }

        private void txtBookListFilepath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "書單統整檔(*.xlsx)|*.xlsx";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtBookListFilepath.Text = dlg.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, ()=>
            {
                FileInfo fi = new FileInfo(txtBookListFilepath.Text);
                if (!fi.Exists)
                {
                    Misc.ShowMessageBox("檔案不存在。");
                    return;
                }

                using (var ctx = new MetaDatabaseEntities())
                {
                    //# import to MetaDatabase.mdf
                    _logger.Info("# 匯入書單統整檔：");
                    int rowCnt = DoImportBooklist(fi, ctx);
                    _logger.Info("匯入完成。匯入 {0:N0} 筆。", rowCnt);

                    // refresh UI
                    bsBOOKLIST.DataSource = ctx.BOOKLIST.Local;
                    this.MainForm.UpdateStatusLabel1(string.Format("筆數：{0:N0}", rowCnt));
                }

            });
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, () =>
            {
                using (var ctx = new MetaDatabaseEntities())
                {
                    // GO

                    //## 檢查「屬性」與推薦欄位
                    /// 與產生 right.html 相關
                    /// [#屬性#] == "總編|兩者" => [#推薦單位#] [#推薦總編#] [#職銜#] [#總編推薦文#]
                    /// [#屬性#] == "職人|兩者" => [#推薦職人店別#] [#職人姓名#] [#職人推薦文#]

                    //## 檢查圖檔來源是否存在
                    int notExistsCounter = 0;
                    int counter = 0;
                    StringBuilder sbNotExistFields = new StringBuilder();

                    _logger.Info("# 檢查「屬性」與推薦欄位：");
                    foreach (var info in ctx.BOOKLIST)
                    {
                        sbNotExistFields.Clear();

                        if (info.屬性 == "總編" || info.屬性 == "兩者")
                        {
                            sbNotExistFields.Clear();

                            if (string.IsNullOrWhiteSpace(info.推薦單位))
                                sbNotExistFields.Append("推薦單位; ");

                            if (string.IsNullOrWhiteSpace(info.推薦總編))
                                sbNotExistFields.Append("推薦總編; ");

                            if (string.IsNullOrWhiteSpace(info.職銜))
                                sbNotExistFields.Append("職銜; ");

                            if (string.IsNullOrWhiteSpace(info.總編推薦文))
                                sbNotExistFields.Append("總編推薦文; ");                              
                        }
                        else if(info.屬性 == "職人" || info.屬性 == "兩者")
                        {
                            if (string.IsNullOrWhiteSpace(info.推薦職人店別))
                                sbNotExistFields.Append("推薦職人店別; ");

                            if (string.IsNullOrWhiteSpace(info.職人姓名))
                                sbNotExistFields.Append("職人姓名; ");

                            if (string.IsNullOrWhiteSpace(info.職人推薦文))
                                sbNotExistFields.Append("職人推薦文; ");
                        }
                        else
                        {
                            _logger.Info("＊ 項次:{0} - {1} 屬性='{2}' 預期之外的屬性。", info.項次, info.獨立編號, info.屬性);
                            notExistsCounter++;
                        }

                        // 但推薦相關欄位無值
                        if (sbNotExistFields.Length > 0)
                        {
                            _logger.Info("＊ 項次:{0} - {1} 屬性='{2}'，但推薦相關欄位無值：{3}。", info.項次, info.獨立編號, info.屬性, sbNotExistFields);
                            notExistsCounter++;
                        }
                    
                        // next
                        counter++;
                    }

                    _logger.Info("檢查完成。處理 {0:N0} 筆，發現 {1:N0} 個問題。", counter, notExistsCounter);
                }

            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, () =>
            {
                using (var ctx = new MetaDatabaseEntities())
                {
                    //# clear BOOKLIST in MetaDatabase.mdf
                    _logger.Info("# 清除書單統整資料：");

                    ctx.Database.ExecuteSqlCommand("DELETE FROM [BOOKLIST]");

                    // refresh UI
                    bsBOOKLIST.DataSource = ctx.BOOKLIST.Local;

                    _logger.Info("清除完成。");
                }
            });
        }
    }
}

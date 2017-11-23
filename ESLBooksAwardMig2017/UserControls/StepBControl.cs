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
using System.Drawing.Imaging;

namespace ESLBooksAwardMig2017.UserControls
{
    public partial class StepBControl : UserControl
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public StepBControl()
        {
            InitializeComponent();
        }

        #region Biz

        /// <summary>
        /// 判斷 image 01,02,03 的來源目錄。
        /// </summary>
        protected string DoDetermineImageSourceFolder(DirectoryInfo srcFolder, BOOKLIST info)
        {
            if(info.大分類 == "a")
            {
                return string.Format("{0}\\最想賣\\{1}_{2}\\",srcFolder.FullName, info.大分類, info.ISBN);
            }
            else if(info.大分類 == "b")
            {
                return string.Format("{0}\\最想幫孩子說服爸媽買\\{1}_{2}\\", srcFolder.FullName, info.大分類, info.ISBN);
            }
            else if(info.大分類 == "c")
            {
                return string.Format("{0}\\在地作家\\{1}_{2}\\", srcFolder.FullName, info.大分類, info.ISBN);
            }

            // otherwise
            throw new ApplicationException("無法判斷照片來源目錄！");
        }

        /// <summary>
        /// 判斷 image 01,02,03 的目的目錄。
        /// </summary>
        protected DirectoryInfo DoDetermineImageTargetFolder(DirectoryInfo tgtFolder, BOOKLIST info)
        {
            DirectoryInfo imgTgtFolder = new DirectoryInfo(string.Format("{0}\\book\\{1}\\{2}\\", tgtFolder.FullName, info.書落, info.獨立編號));

            // make image target folder
            if (!imgTgtFolder.Exists)
                imgTgtFolder.Create();

            return imgTgtFolder;
        }

        /// <summary>
        /// 判斷 images_books 的目的目錄。
        /// </summary>
        protected DirectoryInfo DoDetermineImageTargetFolder_Books(DirectoryInfo tgtFolder, BOOKLIST info)
        {
            DirectoryInfo imgTgtFolder = new DirectoryInfo(string.Format("{0}\\images_books\\", tgtFolder.FullName));

            // make image target folder
            if (!imgTgtFolder.Exists)
                imgTgtFolder.Create();

            return imgTgtFolder;
        }

        /// <summary>
        /// 判斷 images_books_c 的目的目錄。
        /// </summary>
        protected DirectoryInfo DoDetermineImageTargetFolder_BooksC(DirectoryInfo tgtFolder, BOOKLIST info)
        {
            DirectoryInfo imgTgtFolder = new DirectoryInfo(string.Format("{0}\\images_books_c\\", tgtFolder.FullName));

            // make image target folder
            if (!imgTgtFolder.Exists)
                imgTgtFolder.Create();

            return imgTgtFolder;
        }

        protected void DoMakeImageThumbnail(FileInfo fiImage, FileInfo fiThumbnail, int fixWidth = 0, int fixHeight = 0)
        {
            using (Image img = Image.FromFile(fiImage.FullName))
            {
                ImageFormat fmt = img.RawFormat; //取得影像的格式

                // 固定寬, 浮動高
                if (fixWidth != 0 && fixHeight == 0)
                {
                    fixHeight = (int)((double)fixWidth / (double)img.Width * (double)img.Height);
                }
                // 固定高, 浮動寬
                else if (fixHeight != 0 && fixWidth == 0)
                {
                    fixWidth = (int)((double)fixHeight / (double)img.Height * (double)img.Width);
                }

                // make thumbnail image
                using (Bitmap thumb = new Bitmap(img, new Size(fixWidth, fixHeight)))
                {
                    thumb.Save(fiThumbnail.FullName, fmt);
                }
            }
        }

        protected bool ThumbnailCallback()
        {
            return true;
        }

        #endregion

        private void txtBookPhotoFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtBookPhotoFolder.Text = dlg.SelectedPath;
            }
        }

        private void txtTargetBaseFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtTargetBaseFolder.Text = dlg.SelectedPath;
            }
        }

        private void btnTransImg_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, ()=> 
            {
                // resource
                DirectoryInfo srcFolder = new DirectoryInfo(txtBookPhotoFolder.Text);
                DirectoryInfo tgtFolder = new DirectoryInfo(txtTargetBaseFolder.Text);

                // UI: show progress
                bool isTrial = chkTrial.Checked;
                int trialCount = (int)numTrialCount.Value;
                int counter = 0;

                using (var ctx = new MetaDatabaseEntities())
                {
                    // UI: show progress
                    prgBar.Value = 0;
                    prgBar.Maximum = isTrial ? trialCount : ctx.BOOKLIST.Count();

                    // GO
                    _logger.Info("# 開始轉換圖檔：");
                    foreach (var info in ctx.BOOKLIST)
                    {
                        string imageSrcFolder = DoDetermineImageSourceFolder(srcFolder, info);
                        FileInfo img01src = new FileInfo(imageSrcFolder + "01.png");
                        FileInfo img02src = new FileInfo(imageSrcFolder + "02.jpg");
                        FileInfo img03src = new FileInfo(imageSrcFolder + "03.jpg");

                        DirectoryInfo imgTgtFolder = DoDetermineImageTargetFolder(tgtFolder, info);
                        FileInfo img01tgt = new FileInfo(imgTgtFolder.FullName + "\\01.png");
                        FileInfo img02tgt = new FileInfo(imgTgtFolder.FullName + "\\02.jpg");
                        FileInfo img03tgt = new FileInfo(imgTgtFolder.FullName + "\\03.jpg");

                        // copy image
                        if (!img01src.Exists) throw new ApplicationException(string.Format("01.png複製失敗!來源檔不存在{0}。", img01src.FullName));
                        img01src.CopyTo(img01tgt.FullName, true);
                        _logger.Info("Copy 01.png: 項次:{0} - {1} - {2}", info.項次, info.獨立編號, info.推薦書籍);
                        if (!img01tgt.Exists) throw new ApplicationException(string.Format("01.png複製失敗!目的檔不存在{0}。", img01tgt.FullName));

                        if (!img02src.Exists) throw new ApplicationException(string.Format("02.jpg複製失敗!來源檔不存在{0}。", img02src.FullName));
                        img02src.CopyTo(img02tgt.FullName, true);
                        _logger.Info("Copy 02.jgp: 項次:{0} - {1} - {2}", info.項次, info.獨立編號, info.推薦書籍);
                        if (!img02tgt.Exists) throw new ApplicationException(string.Format("02.jpg複製失敗!目的檔不存在{0}。", img02tgt.FullName));

                        if (!img03src.Exists) throw new ApplicationException(string.Format("03.jpg複製失敗!來源檔不存在{0}。", img03src.FullName));
                        img03src.CopyTo(img03tgt.FullName, true);
                        _logger.Info("Copy 03.jgp: 項次:{0} - {1} - {2}", info.項次, info.獨立編號, info.推薦書籍);
                        if (!img03tgt.Exists) throw new ApplicationException(string.Format("03.jpg複製失敗!目的檔不存在{0}。", img03tgt.FullName));

                        //## 縮圖 
                        DirectoryInfo imgBkTgtFolder = DoDetermineImageTargetFolder_Books(tgtFolder, info);
                        FileInfo imgBKtgt = new FileInfo(string.Format("{0}\\{1}.jpg", imgBkTgtFolder.FullName, info.獨立編號));

                        DirectoryInfo imgBkcTgtFolder = DoDetermineImageTargetFolder_BooksC(tgtFolder, info);
                        FileInfo imgBKCtgt = new FileInfo(string.Format("{0}\\{1}.jpg", imgBkcTgtFolder.FullName, info.獨立編號));

                        //# copy 03.jpb → images_books, 固定寬度 300px
                        if (!img03src.Exists) throw new ApplicationException(string.Format("03.jpg複製失敗!來源檔不存在{0}。", img03src.FullName));
                        DoMakeImageThumbnail(img03src, imgBKtgt, fixWidth: 300);
                        _logger.Info("Thumbnail images_books: 項次:{0} - {1} - {2}", info.項次, info.獨立編號, info.推薦書籍);
                        if (!imgBKtgt.Exists) throw new ApplicationException(string.Format("images_books產生失敗!目的檔不存在{0}。", imgBKtgt.FullName));

                        //# copy 02.jpb → images_books_c, 固定高度 600px
                        if (!img02src.Exists) throw new ApplicationException(string.Format("02.jpg複製失敗!來源檔不存在{0}。", img02src.FullName));
                        DoMakeImageThumbnail(img02src, imgBKCtgt, fixHeight: 600);
                        _logger.Info("Thumbnail images_books_c: 項次:{0} - {1} - {2}", info.項次, info.獨立編號, info.推薦書籍);
                        if (!imgBKCtgt.Exists) throw new ApplicationException(string.Format("images_books_c產生失敗!目的檔不存在{0}。", imgBKCtgt.FullName));

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

        private void btnTransImgPrecheck_Click(object sender, EventArgs e)
        {
            TemplateMethods.WatiCursorAndCatchAndLog(this, () =>
            {
                // resource
                DirectoryInfo srcFolder = new DirectoryInfo(txtBookPhotoFolder.Text);
                DirectoryInfo tgtFolder = new DirectoryInfo(txtTargetBaseFolder.Text);

                // UI: show progress
                bool isTrial = chkTrial.Checked;
                int trialCount = (int)numTrialCount.Value;
                int counter = 0;

                using (var ctx = new MetaDatabaseEntities())
                {
                    // UI: show progress
                    prgBar.Value = 0;
                    prgBar.Maximum = isTrial ? trialCount : ctx.BOOKLIST.Count();

                    // GO
                    //## 檢查圖檔來源是否存在
                    int notExistsCounter = 0;
                    _logger.Info("# 檢查圖檔來源不存在：");
                    foreach (var info in ctx.BOOKLIST)
                    {
                        string imageSrcFolder = DoDetermineImageSourceFolder(srcFolder, info);
                        FileInfo img01src = new FileInfo(imageSrcFolder + "01.png");
                        FileInfo img02src = new FileInfo(imageSrcFolder + "02.jpg");
                        FileInfo img03src = new FileInfo(imageSrcFolder + "03.jpg");

                        if (!img01src.Exists)
                        {
                            notExistsCounter++;
                            _logger.Info("＊ 圖檔來源不存在，項次:{0} - {1} - 01.png 推薦書籍:{2}", info.項次, info.獨立編號, info.推薦書籍);
                            _logger.Info("Image path: {0}", img01src.FullName);
                        }
                        
                        if (!img02src.Exists)
                        {
                            notExistsCounter++;
                            _logger.Info("＊ 圖檔來源不存在，項次:{0} - {1} - 02.jpg 推薦書籍:{2}", info.項次, info.獨立編號, info.推薦書籍);
                            _logger.Info("Image path: {0}", img02src.FullName);
                        }
                        
                        if (!img03src.Exists)
                        {
                            notExistsCounter++;
                            _logger.Info("＊ 圖檔來源不存在，項次:{0} - {1} - 03.jpg 推薦書籍:{2}", info.項次, info.獨立編號, info.推薦書籍);
                            _logger.Info("Image path: {0}", img03src.FullName);
                        }
                        
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

                    _logger.Info("檢查完成。處理 {0:N0} 筆，有 {1:N0} 張圖檔不存在。", counter, notExistsCounter);
                }
            });
        }

        //private void btnTransImg2_Click(object sender, EventArgs e)
        //{
        //    TemplateMethods.WatiCursorAndCatchAndLog(this, ()=>
        //    {
        //        // resource
        //        DirectoryInfo srcFolder = new DirectoryInfo(txtBookPhotoFolder.Text);
        //        DirectoryInfo tgtFolder = new DirectoryInfo(txtTargetBaseFolder.Text);
        //
        //        bool isTrial = chkTrial.Checked;
        //        int trialCount = (int)numTrialCount.Value;
        //        int counter = 0;
        //
        //        using (var ctx = new MetaDatabaseEntities())
        //        {
        //            foreach (var info in ctx.BOOKLIST)
        //            {
        //                string imageSrcFolder = DoDetermineImageSourceFolder(srcFolder, info);
        //                FileInfo img02src = new FileInfo(imageSrcFolder + "02.jpg");
        //                FileInfo img03src = new FileInfo(imageSrcFolder + "03.jpg");
        //
        //                //
        //                DirectoryInfo imgBkTgtFolder = DoDetermineImageTargetFolder_Books(tgtFolder, info);
        //                FileInfo imgBKtgt = new FileInfo(string.Format("{0}\\{1}.jpg", imgBkTgtFolder.FullName, info.獨立編號));
        //
        //                DirectoryInfo imgBkcTgtFolder = DoDetermineImageTargetFolder_BooksC(tgtFolder, info);
        //                FileInfo imgBKCtgt = new FileInfo(string.Format("{0}\\{1}.jpg", imgBkcTgtFolder.FullName, info.獨立編號));
        //
        //                //# copy 03.jpb → images_books, 固定寬度 300px
        //                if (!img03src.Exists) throw new ApplicationException(string.Format("img03複製失敗!來源檔不存在{0}。", img03src.FullName));                       
        //                DoMakeImageThumbnail(img03src, imgBKtgt, fixWidth:300);
        //                _logger.Info("Image Thumbnail {0} → {1}", img03src.FullName, imgBKtgt.FullName);
        //                if (!imgBKtgt.Exists) throw new ApplicationException(string.Format("images_books複製失敗!目的檔不存在{0}。", imgBKtgt.FullName));
        //
        //                //# copy 02.jpb → images_books_c, 固定高度 600px
        //                if (!img02src.Exists) throw new ApplicationException(string.Format("img02複製失敗!來源檔不存在{0}。", img02src.FullName));
        //                DoMakeImageThumbnail(img02src, imgBKCtgt, fixHeight: 600);
        //                _logger.Info("Copy {0} → {1}", img02src.FullName, imgBKCtgt.FullName);
        //                if (!imgBKCtgt.Exists) throw new ApplicationException(string.Format("images_books_c複製失敗!目的檔不存在{0}。", imgBKCtgt.FullName));
        //
        //                // next
        //                counter++;
        //
        //                // trial
        //                if (isTrial && counter >= trialCount)
        //                    break;
        //            }
        //
        //            _logger.Info("處理 {0:N0} 筆", counter);
        //        }
        //    });
        //}
    }
}

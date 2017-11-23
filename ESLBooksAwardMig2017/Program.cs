using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESLBooksAwardMig2017
{
    static class Program
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Unhandled Exception 
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new Form2());
        }

        #region Unhandled Exception

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                _logger.Fatal(e.Exception, e.Exception.Message);
                MessageBox.Show(e.Exception.Message, "Unhandled Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.Message);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception exObj = (Exception)e.ExceptionObject;
                _logger.Fatal(exObj, exObj.Message);
                MessageBox.Show(exObj.Message, "Unhandled UI Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.Message);
            }
        }

        #endregion
    }
}

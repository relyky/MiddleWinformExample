using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ESLBooksAwardMig2017
{
    public partial class Form2 : Form
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public Form2()
        {
            InitializeComponent();

            // for NLog
            _mainForm = this;
        }

        #region for NLog

        private static Form2 _mainForm = null; // the singleton form / Mainframe

        /// <summary>
        /// MethodCall - NLog
        /// </summary>
        public static void LogMethod(string longdate, string level, string message)
        {
            Debug.WriteLine(string.Format("NLog → {0} {1} {2}", longdate, level, message));

            try
            {
                if(_mainForm != null)
                {
                    _mainForm.txtMessage.AppendText(string.Format("{0:HH:mm:ss} {1} {2}\r\n", Convert.ToDateTime(longdate), level, message));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format(">>> EXCEPTION : {0} : {1}", ex.GetType().Name, ex.Message));
            }
        }

        #endregion

        public void UpdateStatusLabel1(string note)
        {
            this.m_statusLabel1.Text = note;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Data;
using System.Windows.Forms;

namespace ESLBooksAwardMig2017
{
    internal class Misc
    {
        static public void ShowMessageBox(string msg, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show("檔案不存在", icon.ToString(), MessageBoxButtons.OK, icon);
        }
    }
}

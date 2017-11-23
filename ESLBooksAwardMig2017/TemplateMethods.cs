using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESLBooksAwardMig2017
{
    internal class TemplateMethods
    {
        static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        static public void WatiCursorAndCatchAndLog(object _this, Action action, [CallerMemberName] string memberName = "")
        {
            _logger.Trace("{0} on {1} : ENTER", memberName, _this.GetType().Name);
            Control _thisCtrl = _this as Control;
            try
            {
                if (_thisCtrl != null) _thisCtrl.Cursor = Cursors.WaitCursor;

                action.Invoke();

                _logger.Trace("{0} : DONE", memberName);
                // return result;
            }
            catch(Exception ex)
            {
                _logger.Fatal(ex, "EXCEPTION >>> {0}", ex.Message);
                MessageBox.Show(ex.Message, "EXCEPTION!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //throw;
            }
            finally
            {
                if (_thisCtrl != null) _thisCtrl.Cursor = Cursors.Default;
                _logger.Trace("{0} : LEAVE", memberName);
            }
            
        }
    }
}

using StarLocationCorrection.Views;
using System.Windows.Forms;

namespace StarLocationCorrection.UI
{
    internal class MessageBoxService : IMessageBox
    {
        public void ShowError(string message)
        {
            MessageBox.Show(message,"Error");
        }
    }
}

using StarLocationCorrection.Presenters;
using StarLocationCorrection.UI;
using System;
using System.Windows.Forms;
using TelescopePosCorrection.Models;

namespace StarLocationCorrection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var model = new TelescopePositionCorrectionModel();
            Application.Run(new MainForm(model));
        }
    }
}

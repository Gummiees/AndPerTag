using AndPerTagCore.Forms;
using AndPerTagCore.Utilities;
using System;
using System.Windows.Forms;

namespace AndPerTagCore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                Messages.ShowErrorMessage($"Send a screen capture with this info: {e.Message} - {e.StackTrace}", "Fatal error");
            }
        }
    }
}
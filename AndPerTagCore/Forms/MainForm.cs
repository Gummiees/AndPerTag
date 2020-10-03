using AndPerTag.Events;
using AndPerTag.Services;
using System;
using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            GlobalKeyEvents globalKeyEvents = new GlobalKeyEvents();
            globalKeyEvents.SubscribeGlobal();
            FormClosing += globalKeyEvents.Main_Closing;
            globalKeyEvents.macroEventHandler += MacroEventListener;
        }

        private void MacroEventListener(object sender, MacroEventArgs e)
        {
            if (e.Found)
            {
                ShowBalloonTip($"Macro '{e.UserText}' found and copied to the clipboard");
            }
            else
            {
                ShowBalloonTip($"Macro '{e.UserText}' was not found", ToolTipIcon.Warning);
            }
        }

        /// <summary>
        /// If the form is minimized, hide it from the task bar and show the balloon tooltip.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                ShowBalloonTip("AndPerTag is still working");
                this.Hide();
            }
        }

        /// <summary>
        /// FIXME: Shows a Balloon tip on the tray icon.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        private void ShowBalloonTip(string title, ToolTipIcon? icon = null)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = "Balloon Tip Text.";
            notifyIcon.BalloonTipIcon = icon ?? ToolTipIcon.Info;
            notifyIcon.ShowBalloonTip(10000);
        }

        /// <summary>
        /// Opens up the program once again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }
    }
}

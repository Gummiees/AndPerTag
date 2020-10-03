using AndPerTag.Events;
using AndPerTag.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AndPerTag.Forms
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
            SetNotifyIcon();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                ShowBalloonTip("AndPerTag is still working");
            }
        }

        /// <summary>
        /// Sets the default configuration for the tray icon and sets the program as minimized.
        /// </summary>
        private void SetNotifyIcon()
        {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
            notifyIcon.Text = "AndPerTag - Macros";
            notifyIcon.Icon = new Icon("Assets/Icon/andpertag_logo.ico");
            ShowBalloonTip("AndPerTag is still working");
        }

        /// <summary>
        /// FIXME: Shows a Balloon tip on the tray icon.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        private void ShowBalloonTip(string title, ToolTipIcon? icon = null)
        {
            notifyIcon.ShowBalloonTip(10000);
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = "Balloon Tip Text.";
            notifyIcon.BalloonTipIcon = icon ?? ToolTipIcon.Info;
        }

        /// <summary>
        /// Opens up the program once again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}

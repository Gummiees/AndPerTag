using AndPerTag.Events;
using AndPerTag.Services;
using AndPerTagCore.Services;
using System;
using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class MainForm : Form
    {
        private readonly TagsService tagsService = new TagsService();
        private readonly MacroService macroService;

        public MainForm()
        {
            InitializeComponent();

            GlobalKeyEvents globalKeyEvents = new GlobalKeyEvents();
            globalKeyEvents.SubscribeGlobal();
            FormClosing += globalKeyEvents.Main_Closing;
            globalKeyEvents.macroEventHandler += MacroEventListener;

            macroService = new MacroService(tagsService);

            tagsService.PrintTags(Controls);
            macroService.PrintMacros(Controls);
        }

        private void MacroEventListener(object sender, MacroEventArgs e)
        {
            if (!e.Found)
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
                HideWindow();
            }
        }

        /// <summary>
        /// FIXME: Shows a Balloon tip on the tray icon.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        private void ShowBalloonTip(string text, ToolTipIcon? icon = null)
        {
            notifyIcon.BalloonTipTitle = "AndPerTags - Macro";
            notifyIcon.BalloonTipText = text;
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
        private void HideWindow()
        {
            Hide();
            this.ShowInTaskbar = false;
            ShowBalloonTip("AndPerTag is working on background");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // HideWindow();
        }
    }
}

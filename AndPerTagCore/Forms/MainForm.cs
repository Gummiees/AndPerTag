using AndPerTag.Events;
using AndPerTag.Services;
using AndPerTagCore.Services;
using AndPerTagCore.Utilities;
using System;
using System.Collections.Generic;
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
            globalKeyEvents.MacroEventHandler += MacroEventListener;

            macroService = new MacroService(tagsService);

            tagsService.PrintTags(splitContainer.Panel1.Controls);
            macroService.PrintMacros(splitContainer.Panel2.Controls);
            macroService.RefreshMacrosHandler += RemoveMacrosEvent;
            tagsService.refreshTagsHandler += RemoveTagsEvent;
        }

        private void MacroEventListener(object sender, EventArgs args)
        {
            if (sender is MacroEvent e && !e.Found)
            {
                ShowBalloonTip($"Macro '{e.UserText}' was not found", ToolTipIcon.Warning);
            }
        }

        /// <summary>
        /// Remove all the buttons from the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveMacrosEvent(object sender, EventArgs e)
        {
            RemoveMacroButtons();
            macroService.PrintMacros(splitContainer.Panel2.Controls);
        }

        /// <summary>
        /// Remove all the buttons from the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTagsEvent(object sender, EventArgs e)
        {
            RemoveTagButtons();
            RemoveMacroButtons();
            tagsService.PrintTags(splitContainer.Panel1.Controls);
            macroService.PrintMacros(splitContainer.Panel2.Controls);
        }

        /// <summary>
        /// Remove all the buttons from the tag panel.
        /// </summary>
        private void RemoveTagButtons()
        {
            List<string> removableControls = new List<string>();
            foreach (Control control in splitContainer.Panel1.Controls)
            {
                if (control.Tag != null && control.Tag.ToString().Equals(GlobalConstants.removableTag))
                {
                    removableControls.Add(control.Name);
                }
            }

            foreach (string controlName in removableControls)
            {
                splitContainer.Panel1.Controls.RemoveByKey(controlName);
            }
        }

        /// <summary>
        /// Remove all the buttons from the macro panel.
        /// </summary>
        private void RemoveMacroButtons()
        {
            List<string> removableControls = new List<string>();
            foreach (Control control in splitContainer.Panel2.Controls)
            {
                if (control.Tag != null)
                {
                    if (control.Tag.ToString().Equals(GlobalConstants.removableTagMacro))
                    {
                        removableControls.Add(control.Name);
                    }
                }
            }

            foreach (string controlName in removableControls)
            {
                splitContainer.Panel2.Controls.RemoveByKey(controlName);
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
        /// Shows a Balloon tip on the tray icon.
        /// </summary>
        /// <param name="text"></param>
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void createTagButton_Click(object sender, EventArgs e)
        {
            tagsService.CreateTagEvent();
        }

        private void addMacroButton_Click(object sender, EventArgs e)
        {
            macroService.CreateMacroEvent();
        }
    }
}
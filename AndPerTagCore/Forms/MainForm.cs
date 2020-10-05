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
            globalKeyEvents.macroEventHandler += MacroEventListener;

            macroService = new MacroService(tagsService);

            tagsService.PrintTags(Controls);
            macroService.PrintMacros(Controls);
            macroService.refreshMacrosHandler += RemoveMacrosEvent;
            tagsService.refreshTagsHandler += RemoveTagsEvent;

        }

        private void MacroEventListener(object sender, MacroEventArgs e)
        {
            if (!e.Found)
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
            RemoveButtons(false);
            macroService.PrintMacros(Controls);
        }

        /// <summary>
        /// Remove all the buttons from the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTagsEvent(object sender, EventArgs e)
        {
            RemoveButtons(true);
            tagsService.PrintTags(Controls);
            macroService.PrintMacros(Controls);
        }

        /// <summary>
        /// Remove all the buttons from the screen. Can be done only to macros.
        /// </summary>
        /// <param name="removeTags"></param>
        private void RemoveButtons(bool removeTags)
        {
            List<string> removableControls = new List<string>();
            foreach (Control control in Controls)
            {
                if (control.Tag != null)
                {
                    if (control.Tag.ToString().Equals(GlobalConstants.removableTagMacro))
                    {
                        removableControls.Add(control.Name);
                    }
                    else if (removeTags && control.Tag.ToString().Equals(GlobalConstants.removableTag))
                    {
                        removableControls.Add(control.Name);
                    }
                }
            }

            foreach (string controlName in removableControls)
            {
                Controls.RemoveByKey(controlName);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO: Create About window.
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        /// <summary>
        /// Confirmation before deleting a tag.
        /// </summary>
        /// <param name="tagName"></param>
        private void ConfirmDeleteTag(string tagName)
        {
            var confirmResult = MessageBox.Show(
                    "Are you sure to delete this tag?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo
                );

            if (confirmResult == DialogResult.Yes)
            {
                tagsService.RemoveTag(tagName);
            }
        }
    }
}
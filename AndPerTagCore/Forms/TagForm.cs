using AndPerTag.Models;
using AndPerTagCore.Events;
using AndPerTagCore.Utilities;
using System;
using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class TagForm : Form
    {
        #region GLOBAL VARIABLES

        private Tag OriginalTag { get; set; }

        #endregion GLOBAL VARIABLES

        #region EVENTS

        public event EventHandler AcceptEventHandler;

        #endregion EVENTS

        public TagForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Public setter for the original tag.
        /// </summary>
        /// <param name="originalTag"></param>
        public void SetOriginalTag(Tag originalTag)
        {
            OriginalTag = originalTag;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Only send event if name and color are filled.
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text) && colorDialog.Color != null)
            {
                EditTagEvent editTagEvent = new EditTagEvent
                {
                    Original = OriginalTag,
                    Created = new Tag
                    {
                        Name = nameTextBox.Text.Trim(),
                        Color = $"#{colorDialog.Color.ToArgb() & 0x00FFFFFF:X6}",
                        Macros = OriginalTag?.Macros
                    }
                };

                AcceptEventHandler.Invoke(editTagEvent, e);
                Close();
            }
            else
            {
                Messages.InvalidForm();
            }
        }
    }
}
﻿using AndPerTag.Models;
using AndPerTagCore.Models.Events;
using AndPerTagCore.Utilities;
using System;
using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class TagForm : Form
    {
        #region GLOBAL VARIABLES
        public Tag originalTag;
        #endregion

        #region EVENTS
        public event EventHandler acceptEventHandler;
        #endregion

        public TagForm()
        {
            InitializeComponent();
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
                EditEvent<Tag> editTagEvent = new EditEvent<Tag>()
                {
                    original = originalTag,
                    created = new Tag()
                    {
                        Name = nameTextBox.Text,
                        Color = $"#{colorDialog.Color.ToArgb() & 0x00FFFFFF:X6}",
                        Macros = originalTag?.Macros
                    }
                };

                acceptEventHandler?.Invoke(editTagEvent, e);
                Close();
            }
            else
            {
                Messages.InvalidForm();
            }
        }
    }
}

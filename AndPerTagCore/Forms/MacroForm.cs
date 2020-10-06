using AndPerTag.Models;
using AndPerTagCore.Models;
using AndPerTagCore.Models.Events;
using AndPerTagCore.Utilities;
using System;
using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class MacroForm : Form
    {
        #region GLOBAL VARIABLES

        public Macro originalMacro;

        #endregion GLOBAL VARIABLES

        #region EVENTS

        public event EventHandler acceptEventHandler;

        #endregion EVENTS

        public MacroForm()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Only send event if name and color are filled.
            if (
                !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(textTextBox.Text) &&
                tagComboBox.SelectedItem != null &&
                tagComboBox.SelectedItem is Tag tag
            )
            {
                EditMacroEvent editTagEvent = new EditMacroEvent()
                {
                    Original = originalMacro,
                    Created = new EditMacro()
                    {
                        Macro = new Macro()
                        {
                            Name = nameTextBox.Text,
                            Text = textTextBox.Text
                        },
                        Tag = tag
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

        private void MacroForm_Load(object sender, EventArgs e)
        {
        }
    }
}
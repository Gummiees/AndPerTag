using AndPerTag.Models;
using AndPerTagCore.Events;
using AndPerTagCore.Models;
using AndPerTagCore.Utilities;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class MacroForm : Form
    {
        #region GLOBAL VARIABLES

        private Macro OriginalMacro { get; set; }
        private readonly Regex regex = new Regex(@"^[a-zA-Z0-9]+$");

        #endregion GLOBAL VARIABLES

        #region EVENTS

        public event EventHandler AcceptEventHandler;

        #endregion EVENTS

        public MacroForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Public setter for the original macro.
        /// </summary>
        /// <param name="originalMacro"></param>
        public void SetOriginalMacro(Macro originalMacro)
        {
            OriginalMacro = originalMacro;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Only send event if name and color are filled and the name is correct.
            bool isMatch = regex.IsMatch(nameTextBox.Text);
            if (
                !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                isMatch &&
                !string.IsNullOrWhiteSpace(textTextBox.Text) &&
                tagComboBox.SelectedItem != null &&
                tagComboBox.SelectedItem is Tag tag
            )
            {
                EditMacroEvent editTagEvent = new EditMacroEvent
                {
                    Original = OriginalMacro,
                    Created = new EditMacro
                    {
                        Macro = new Macro
                        {
                            Name = nameTextBox.Text.Trim(),
                            Text = textTextBox.Text.Trim()
                        },
                        Tag = tag
                    }
                };

                AcceptEventHandler.Invoke(editTagEvent, e);
                Close();
            }
            else if (!isMatch)
            {
                Messages.ShowWarningMessage("Currently the macro name can only contain letters and numbers", "Incorrect macro name");
            }
            else
            {
                Messages.InvalidForm();
            }
        }
    }
}
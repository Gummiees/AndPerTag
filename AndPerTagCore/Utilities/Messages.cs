using System.Windows.Forms;

namespace AndPerTagCore.Utilities
{
    public static class Messages
    {
        public static void ShowMessage(MessageBoxIcon? type, string text = null, string title = null)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, type ?? MessageBoxIcon.Error);
        }

        public static void ShowErrorMessage(string text = null, string title = null)
        {
            ShowMessage(MessageBoxIcon.Error, text, title);
        }

        public static void ShowWarningMessage(string text = null, string title = null)
        {
            ShowMessage(MessageBoxIcon.Warning, text, title);
        }

        public static void ShowInfoMessage(string text = null, string title = null)
        {
            ShowMessage(MessageBoxIcon.Information, text, title);
        }

        public static void ShowHelpMessage(string text = null, string title = null)
        {
            ShowMessage(MessageBoxIcon.Question, text, title);
        }

        public static void InvalidForm()
        {
            ShowWarningMessage("Please fill all the inputs first.", "Invalid form");
        }

        public static void ErrorSaving()
        {
            ShowErrorMessage("There was an error while saving", "Error saving");
        }

        public static void ErrorParsing()
        {
            ShowErrorMessage("There was an error while parsing the object to a JSON or viceversa", "Error parsing");
        }

        public static DialogResult RemoveDialog(string type, string name)
        {
            return MessageBox.Show(
                    $"Are you sure to remove the {type} '{name}'?",
                    $"AndPerTag - Remove {type}",
                    MessageBoxButtons.YesNo
                );
        }
    }
}
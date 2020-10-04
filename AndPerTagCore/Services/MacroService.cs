using AndPerTag.Models;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AndPerTagCore.Services
{
    public class MacroService
    {
        private TagsService tagService;

        #region CONSTANTS

        private const int leftMargin = 425;
        private const int initialTopMargin = 30;
        private const int topMargin = 50;
        private const int buttonWidth = 350;
        private const int buttonHeight = 40;

        #endregion CONSTANTS

        public MacroService(TagsService tagService)
        {
            this.tagService = tagService;
        }

        /// <summary>
        /// Prints the macros on the main screen.
        /// </summary>
        public void PrintMacros(ControlCollection controls)
        {
            int i = 1;
            foreach (Tag tag in tagService.AllTags.Tags)
            {
                foreach (Macro macro in tag.Macros)
                {
                    Button button = new Button
                    {
                        Top = initialTopMargin + (topMargin * i),
                        Left = leftMargin,
                        Text = $"{macro.Name} ({tag.Name})",
                        BackColor = ColorTranslator.FromHtml(tag.Color),
                        Size = new Size(buttonWidth, buttonHeight),
                        TextAlign = ContentAlignment.MiddleLeft,
                        FlatStyle = FlatStyle.Flat
                    };
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Black;
                    controls.Add(button);
                    i++;
                }
            }
        }
    }
}
using AndPerTag.Models;
using AndPerTag.Utilities;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AndPerTagCore.Services
{
    public class TagsService
    {
        public AllTags AllTags { get; set; }

        #region CONSTANTS

        private const int leftMargin = 15;
        private const int initialTopMargin = 50;
        private const int topMargin = 50;
        private const int buttonWidth = 285;
        private const int buttonHeight = 40;

        #endregion CONSTANTS

        /// <summary>
        /// Gets all tags from the JSON file.
        /// </summary>
        /// <returns></returns>
        public AllTags ReadTags()
        {
            AllTags = JSONUtilities.Read();
            return AllTags;
        }

        /// <summary>
        /// Prints the tags on the main screen.
        /// </summary>
        public void PrintTags(ControlCollection controls)
        {
            ReadTags();
            int i = 1;
            foreach (Tag tag in AllTags.Tags)
            {
                int top = initialTopMargin + (topMargin * i);
                Button button = new Button
                {
                    Top = top,
                    Left = leftMargin,
                    Text = tag.Name,
                    BackColor = ColorTranslator.FromHtml(tag.Color),
                    Size = new Size(buttonWidth, buttonHeight),
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatStyle = FlatStyle.Flat
                };
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = Color.Black;
                controls.Add(button);
                SmallButtons.PrintEditButton(top, leftMargin + buttonWidth, controls);
                SmallButtons.PrintDeleteButton(top, leftMargin + buttonWidth, controls);
                i++;
            }
        }
    }
}
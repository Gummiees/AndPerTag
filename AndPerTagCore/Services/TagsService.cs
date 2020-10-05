using AndPerTag.Models;
using AndPerTag.Utilities;
using AndPerTagCore.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AndPerTagCore.Services
{
    public class TagsService
    {
        public AllTags AllTags { get; set; }

        #region CONSTANTS

        private const int buttonLeft = 15;

        #endregion CONSTANTS

        #region EVENTS
        public event EventHandler refreshTagsHandler;
        #endregion

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
            int top;
            foreach (Tag tag in AllTags.Tags)
            {
                top = GlobalConstants.buttonInitialTop + (GlobalConstants.buttonTop * i);
                Button button = new Button
                {
                    Top = top,
                    Left = buttonLeft,
                    Text = tag.Name,
                    Name = tag.Name,
                    Tag = GlobalConstants.removableTag,
                    BackColor = ColorTranslator.FromHtml(tag.Color),
                    Size = new Size(GlobalConstants.buttonWidth, GlobalConstants.buttonHeight),
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatStyle = FlatStyle.Flat
                };
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = Color.Black;
                controls.Add(button);

                Button editButton = SmallButtons.GetEditButton(tag.Name, GlobalConstants.removableTag, top, buttonLeft + GlobalConstants.buttonWidth);
                controls.Add(editButton);

                Button deleteButton = SmallButtons.GetDeleteButton(tag.Name, GlobalConstants.removableTag, top, buttonLeft + GlobalConstants.buttonWidth);
                deleteButton.Click += new EventHandler(RemoveTagEvent);
                controls.Add(deleteButton);

                i++;
            }
        }

        /// <summary>
        /// Returns a tag with the given name if found.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public Tag GetTag(string tagName)
        {
            foreach (Tag tag in AllTags.Tags)
            {
                if (tag.Name.Equals(tagName))
                {
                    return tag;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates an empty tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="save"></param>
        public void CreateTag(Tag tag, bool save = true)
        {
            if (GetTag(tag.Name) == null)
            {
                AllTags.Tags.Add(tag);

                if (save)
                {
                    JSONUtilities.Write(AllTags);
                    refreshTagsHandler?.Invoke(null, null);
                }
            }
            else
            {
                throw new ArgumentException($"Tag '{tag.Name}' already exists");
            }
        }

        /// <summary>
        /// Removes the indicated tag.
        /// </summary>
        /// <param name="tagName"></param>
        public void RemoveTag(string tagName, bool save = true)
        {
            Tag tag = GetTag(tagName);

            if (tag == null)
            {
                throw new ArgumentException($"The macro '{tagName}' was not found.");
            }
            else
            {
                AllTags.Tags.Remove(tag);

                if (save)
                {
                    JSONUtilities.Write(AllTags);
                    refreshTagsHandler?.Invoke(tagName, null);
                }
            }
        }

        /// <summary>
        /// Handles the click event on the delete button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTagEvent(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var confirmResult = MessageBox.Show(
                       $"Are you sure to remove the tag '{button.Name}'? All the macros from this tag will be removed!",
                       "Remove tag",
                       MessageBoxButtons.YesNo
                   );

                if (confirmResult == DialogResult.Yes)
                {
                    RemoveTag(button.Name);
                }
            }
        }

        /// <summary>
        /// Removes the original tag and creates the new one.
        /// </summary>
        /// <param name="originalTagName"></param>
        /// <param name="tag"></param>
        /// <param name="save"></param>
        public void EditTag(string originalTagName, Tag tag, bool save = true)
        {
            RemoveTag(originalTagName, false);
            CreateTag(tag, false);

            if (save)
            {
                JSONUtilities.Write(AllTags);
                refreshTagsHandler?.Invoke(null, null);
            }
        }
    }
}
using AndPerTag.Models;
using AndPerTag.Utilities;
using AndPerTagCore.Forms;
using AndPerTagCore.Models.Events;
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

        #region EVENTS

        public event EventHandler refreshTagsHandler;

        #endregion EVENTS

        #region CONSTANTS

        private const string createTagText = "Create new tag";
        private const string editTagText = "Edit tag";

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
            int top;
            foreach (Tag tag in AllTags.Tags)
            {
                top = GlobalConstants.buttonInitialTop + (GlobalConstants.buttonTop * i);
                Button button = new Button
                {
                    Top = top,
                    Left = GlobalConstants.buttonLeft,
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

                Button editButton = SmallButtons.GetEditButton(
                    tag.Name,
                    GlobalConstants.removableTag,
                    top,
                    GlobalConstants.buttonLeft + GlobalConstants.buttonWidth
                );
                editButton.Click += new EventHandler(EditTagEvent);
                controls.Add(editButton);

                Button deleteButton = SmallButtons.GetDeleteButton(
                    tag.Name,
                    GlobalConstants.removableTag,
                    top,
                    GlobalConstants.buttonLeft + GlobalConstants.buttonWidth
                );
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
                Messages.ShowWarningMessage($"The tag '{tag.Name}' already exists", "Already exists");
            }
        }

        /// <summary>
        /// Handles the create button event for a tag.
        /// </summary>
        public void CreateTagEvent()
        {
            Forms.TagForm tagForm = new Forms.TagForm();
            tagForm.tagLabel.Text = createTagText;
            tagForm.acceptEventHandler += AcceptCreateTagEvent;
            tagForm.Show();
        }

        /// <summary>
        /// Handles the accept button on the create form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptCreateTagEvent(object sender, EventArgs e)
        {
            if (sender is EditEvent<Tag> editTagEvent)
            {
                CreateTag(editTagEvent.created);
            }
        }

        /// <summary>
        /// Removes the indicated tag.
        /// </summary>
        /// <param name="tag"></param>
        public void RemoveTag(Tag tag, bool save = true)
        {
            if (tag == null)
            {
                Messages.ShowWarningMessage($"The tag '{tag.Name}' was not found", "Not found");
            }
            else
            {
                AllTags.Tags.Remove(tag);

                if (save)
                {
                    JSONUtilities.Write(AllTags);
                    refreshTagsHandler?.Invoke(tag.Name, null);
                }
            }
        }

        /// <summary>
        /// Removes the indicated tag.
        /// </summary>
        /// <param name="tagName"></param>
        public void RemoveTag(string tagName, bool save = true)
        {
            Tag tag = GetTag(tagName);
            RemoveTag(tag, save);
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
                var confirmResult = Messages.RemoveDialog("tag", button.Name);
                if (confirmResult.Equals(DialogResult.Yes))
                {
                    RemoveTag(button.Name);
                }
            }
        }

        /// <summary>
        /// Removes the original tag and creates the new one.
        /// </summary>
        /// <param name="originalTag"></param>
        /// <param name="tag"></param>
        /// <param name="save"></param>
        public void EditTag(Tag originalTag, Tag tag, bool save = true)
        {
            RemoveTag(originalTag, false);
            CreateTag(tag, false);

            if (save)
            {
                JSONUtilities.Write(AllTags);
                refreshTagsHandler?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Handles the click event on the edit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTagEvent(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Tag tag = GetTag(button.Name);
                Forms.TagForm tagForm = new Forms.TagForm
                {
                    originalTag = tag,
                };
                tagForm.nameTextBox.Text = tag.Name;
                tagForm.tagLabel.Text = editTagText;
                tagForm.colorButton.BackColor = ColorTranslator.FromHtml(tag.Color);
                tagForm.colorDialog.Color = ColorTranslator.FromHtml(tag.Color);

                tagForm.acceptEventHandler += AcceptEditTagEvent;
                tagForm.Show();
            }
        }

        /// <summary>
        /// Handles the accept button on the edit form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptEditTagEvent(object sender, EventArgs e)
        {
            if (sender is EditEvent<Tag> editTagEvent)
            {
                EditTag(editTagEvent.original, editTagEvent.created);
            }
        }
    }
}
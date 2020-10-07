using AndPerTag.Models;
using AndPerTag.Utilities;
using AndPerTagCore.Forms;
using AndPerTagCore.Models.Events;
using AndPerTagCore.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AndPerTagCore.Services
{
    public class MacroService
    {
        #region EVENTS

        public event EventHandler RefreshMacrosHandler;

        #endregion EVENTS

        #region CONSTANTS

        private readonly TagsService tagService;
        private const string createMacroText = "Create new macro";
        private const string editMacroText = "Edit macro";

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
            int top;
            if (tagService.AllTags.Tags != null)
            {
                foreach (Tag tag in tagService.AllTags.Tags)
                {
                    if (tag.Macros != null)
                    {
                        foreach (Macro macro in tag.Macros)
                        {
                            top = GlobalConstants.buttonInitialTop + (GlobalConstants.buttonTop * i);
                            Button button = new Button
                            {
                                Top = top,
                                Left = GlobalConstants.buttonLeft,
                                Text = $"{macro.Name} ({tag.Name})",
                                Name = macro.Name,
                                Tag = GlobalConstants.removableTagMacro,
                                BackColor = ColorTranslator.FromHtml(tag.Color),
                                Size = new Size(GlobalConstants.buttonWidth, GlobalConstants.buttonHeight),
                                TextAlign = ContentAlignment.MiddleLeft,
                                FlatStyle = FlatStyle.Flat
                            };
                            button.FlatAppearance.BorderSize = 1;
                            button.FlatAppearance.BorderColor = Color.Black;

                            Button editButton = SmallButtons.GetEditButton(
                                macro.Name,
                                GlobalConstants.removableTagMacro,
                                top,
                                GlobalConstants.buttonLeft + GlobalConstants.buttonWidth
                            );
                            editButton.Click += new EventHandler(EditMacroEvent);
                            controls.Add(editButton);

                            Button deleteButton = SmallButtons.GetDeleteButton(
                                macro.Name,
                                GlobalConstants.removableTagMacro,
                                top,
                                GlobalConstants.buttonLeft + GlobalConstants.buttonWidth
                            );
                            deleteButton.Click += new EventHandler(RemoveMacroEvent);
                            controls.Add(deleteButton);

                            controls.Add(button);
                            i++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns a macro with the given name if found in a given tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="macroName"></param>
        /// <returns></returns>
        private Macro GetMacro(Tag tag, string macroName)
        {
            if (tag.Macros != null)
            {
                foreach (Macro macro in tag.Macros)
                {
                    if (macro.Name.Equals(macroName))
                    {
                        return macro;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a macro with the given name if found in a given tag.
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="macroName"></param>
        /// <returns></returns>
        private Macro GetMacro(string tagName, string macroName)
        {
            if (tagService.AllTags.Tags != null)
            {
                foreach (Tag tag in tagService.AllTags.Tags)
                {
                    if (tag.Name.Equals(tagName) && tag.Macros != null)
                    {
                        foreach (Macro macro in tag.Macros)
                        {
                            if (macro.Name.Equals(macroName))
                            {
                                return macro;
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a macro with the given name if found.
        /// </summary>
        /// <param name="macroName"></param>
        /// <returns></returns>
        private Macro GetMacro(string macroName)
        {
            if (tagService.AllTags.Tags != null)
            {
                foreach (Tag tag in tagService.AllTags.Tags)
                {
                    Macro macro = GetMacro(tag, macroName);
                    if (macro != null)
                    {
                        return macro;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Creates a macro inside the given tag.
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="macro"></param>
        /// <param name="save"></param>
        private void CreateMacro(string tagName, Macro macro, bool save = true)
        {
            if (GetMacro(tagName, macro.Name) != null)
            {
                Messages.ShowWarningMessage($"The macro '{macro.Name}' already exists", "Already exists");
            }
            else if (tagService.AllTags.Tags == null)
            {
                Messages.ShowWarningMessage($"The tag '{tagName}' was not found", "Tag not found");
            }
            else
            {
                if (tagService.AllTags.Tags != null)
                {
                    foreach (Tag tag in tagService.AllTags.Tags)
                    {
                        if (tag.Name.Equals(tagName))
                        {
                            if (tag.Macros == null)
                            {
                                tag.Macros = new List<Macro>();
                            }
                            tag.Macros.Add(macro);
                            break;
                        }
                    }
                }

                if (save)
                {
                    JSONUtilities.Write(tagService.AllTags);
                    RefreshMacrosHandler?.Invoke(null, null);
                }
            }
        }

        /// <summary>
        /// Handles the create button event for a macro.
        /// </summary>
        public void CreateMacroEvent()
        {
            if (tagService.AllTags.Tags == null || !tagService.AllTags.Tags.Any())
            {
                Messages.ShowWarningMessage($"To create a macro you first need to have at least one tag", "No tags found");
            }
            else
            {
                MacroForm macroForm = new MacroForm();
                macroForm.macroLabel.Text = createMacroText;
                macroForm.tagComboBox.DataSource = tagService.AllTags.Tags;
                macroForm.tagComboBox.DisplayMember = "Name";
                macroForm.tagComboBox.ValueMember = "Name";
                macroForm.acceptEventHandler += AcceptCreateMacroEvent;
                macroForm.Show();
            }
        }

        /// <summary>
        /// Handles the accept button on the create form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptCreateMacroEvent(object sender, EventArgs e)
        {
            if (sender is EditMacroEvent editMacroEvent)
            {
                CreateMacro(editMacroEvent.Created.Tag.Name, editMacroEvent.Created.Macro);
            }
        }

        /// <summary>
        /// Removes the indicated macro.
        /// </summary>
        /// <param name="macro"></param>
        private void RemoveMacro(Macro macro, bool save = true)
        {
            if (macro != null && tagService.AllTags.Tags != null)
            {
                foreach (Tag tag in tagService.AllTags.Tags)
                {
                    if (tag.Macros.Any(m => m.Equals(macro)))
                    {
                        tag.Macros.Remove(macro);
                        break;
                    }
                }
            }

            if (macro == null)
            {
                Messages.ShowWarningMessage($"The macro '{macro.Name}' was not found", "Not found");
            }
            else if (tagService.AllTags.Tags == null)
            {
                Messages.ShowWarningMessage($"The tag from the macro '{macro}' was not found", "Tag not found");
            }

            if (save)
            {
                JSONUtilities.Write(tagService.AllTags);
                RefreshMacrosHandler?.Invoke(macro.Name, null);
            }
        }

        /// <summary>
        /// Removes the indicated macro.
        /// </summary>
        /// <param name="macroName"></param>
        private void RemoveMacro(string macroName, bool save = true)
        {
            Macro macro = GetMacro(macroName);
            RemoveMacro(macro);
        }

        /// <summary>
        /// Handles the click event on the delete button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveMacroEvent(object sender, EventArgs args)
        {
            if (sender is Button button)
            {
                var confirmResult = Messages.RemoveDialog("macro", button.Name);
                if (confirmResult.Equals(DialogResult.Yes))
                {
                    RemoveMacro(button.Name);
                }
            }
        }

        /// <summary>
        /// Removes the original macro and creates the new one inside the given tag.
        /// </summary>
        /// <param name="originalMacroName"></param>
        /// <param name="tagNameForNewMacro"></param>
        /// <param name="newMacro"></param>
        /// <param name="save"></param>
        private void EditMacro(Macro originalMacro, string tagNameForNewMacro, Macro newMacro, bool save = true)
        {
            RemoveMacro(originalMacro, false);
            CreateMacro(tagNameForNewMacro, newMacro, false);

            if (save)
            {
                JSONUtilities.Write(tagService.AllTags);
                RefreshMacrosHandler?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Handles the click event on the edit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMacroEvent(object sender, EventArgs e)
        {
            if (tagService.AllTags.Tags == null || tagService.AllTags.Tags.Any())
            {
                Messages.ShowWarningMessage($"To create a macro you first need to have at least one tag", "No tags found");
            }
            else if (sender is Button button)
            {
                Macro macro = GetMacro(button.Name);
                MacroForm macroForm = new MacroForm
                {
                    originalMacro = macro
                };
                macroForm.macroLabel.Text = editMacroText;
                macroForm.nameTextBox.Text = macro.Name;
                macroForm.textTextBox.Text = macro.Text;
                macroForm.tagComboBox.DataSource = tagService.AllTags.Tags;
                macroForm.tagComboBox.DisplayMember = "Name";
                macroForm.tagComboBox.ValueMember = "Name";
                macroForm.tagComboBox.SelectedItem = tagService.GetTagByMacro(macro.Name);

                macroForm.acceptEventHandler += AcceptEditMacroEvent;
                macroForm.Show();
            }
        }

        /// <summary>
        /// Handles the accept button on the edit form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptEditMacroEvent(object sender, EventArgs e)
        {
            if (sender is EditMacroEvent editMacroEvent)
            {
                EditMacro(editMacroEvent.Original, editMacroEvent.Created.Tag.Name, editMacroEvent.Created.Macro);
            }
        }
    }
}
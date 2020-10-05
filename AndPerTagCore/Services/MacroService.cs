using AndPerTag.Models;
using AndPerTag.Utilities;
using AndPerTagCore.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AndPerTagCore.Services
{
    public class MacroService
    {
        private TagsService tagService;

        #region CONSTANTS

        private const int buttonLeft = 425;

        #endregion CONSTANTS

        #region EVENTS
        public event EventHandler refreshMacrosHandler;
        #endregion

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
            foreach (Tag tag in tagService.AllTags.Tags)
            {
                foreach (Macro macro in tag.Macros)
                {
                    top = GlobalConstants.buttonInitialTop + (GlobalConstants.buttonTop * i);
                    Button button = new Button
                    {
                        Top = top,
                        Left = buttonLeft,
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

                    Button editButton = SmallButtons.GetEditButton(macro.Name, GlobalConstants.removableTagMacro, top, buttonLeft + GlobalConstants.buttonWidth);
                    controls.Add(editButton);

                    Button deleteButton = SmallButtons.GetDeleteButton(macro.Name, GlobalConstants.removableTagMacro, top, buttonLeft + GlobalConstants.buttonWidth);
                    deleteButton.Click += new EventHandler(RemoveMacroEvent);
                    controls.Add(deleteButton);

                    controls.Add(button);
                    i++;
                }
            }
        }

        /// <summary>
        /// Returns a macro with the given name if found in a given tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="macroName"></param>
        /// <returns></returns>
        public Macro GetMacro(Tag tag, string macroName)
        {
            foreach (Macro macro in tag.Macros)
            {
                if (macro.Name.Equals(macroName))
                {
                    return macro;
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
        public Macro GetMacro(string tagName, string macroName)
        {
            foreach (Tag tag in tagService.AllTags.Tags)
            {
                if (tag.Name.Equals(tagName))
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

            return null;
        }

        /// <summary>
        /// Returns a macro with the given name if found.
        /// </summary>
        /// <param name="macroName"></param>
        /// <returns></returns>
        public Macro GetMacro(string macroName)
        {
            foreach (Tag tag in tagService.AllTags.Tags)
            {
                Macro macro = GetMacro(tag, macroName);
                if (macro != null)
                {
                    return macro;
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
        public void CreateMacro(string tagName, Macro macro, bool save = true)
        {
            if (GetMacro(tagName, macro.Name) == null)
            {
                foreach (Tag tag in tagService.AllTags.Tags)
                {
                    if (tag.Name.Equals(tagName))
                    {
                        tag.Macros.Add(macro);
                        break;
                    }
                }

                if (save)
                {
                    JSONUtilities.Write(tagService.AllTags);
                    refreshMacrosHandler?.Invoke(null, null);
                }
            }
            else
            {
                throw new ArgumentException($"Macro '{macro.Name}' already exists");
            }
        }

        /// <summary>
        /// Removes the indicated macro.
        /// </summary>
        /// <param name="macroName"></param>
        private void RemoveMacro(string macroName, bool save = true)
        {
            Macro macro = null;
            foreach (Tag tag in tagService.AllTags.Tags)
            {
                macro = GetMacro(tag, macroName);
                if (macro != null)
                {
                    tag.Macros.Remove(macro);
                    break;
                }
            }

            if (macro == null)
            {
                throw new ArgumentException($"The macro '{macroName}' was not found.");
            }

            if (save)
            {
                JSONUtilities.Write(tagService.AllTags);
                refreshMacrosHandler?.Invoke(macroName, null);
            }
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
                var confirmResult = MessageBox.Show(
                        $"Are you sure to remove the macro '{button.Name}'?",
                        "Remove macro",
                        MessageBoxButtons.YesNo
                    );

                if (confirmResult == DialogResult.Yes)
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
        public void EditMacro(string originalMacroName, string tagNameForNewMacro, Macro newMacro, bool save = true)
        {
            RemoveMacro(originalMacroName, false);
            CreateMacro(tagNameForNewMacro, newMacro, false);

            if (save)
            {
                JSONUtilities.Write(tagService.AllTags);
                refreshMacrosHandler?.Invoke(null, null);
            }
        }
    }
}
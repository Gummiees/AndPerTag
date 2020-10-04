using AndPerTag.Events;
using AndPerTag.Models;
using AndPerTag.Utilities;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsHook;

namespace AndPerTag.Services
{
    public class GlobalKeyEvents
    {
        #region GLOBAL VARIABLES
        private IKeyboardMouseEvents m_GlobalHook;
        private bool pressedAndpersand = false;
        private string macroName;
        #endregion

        #region EVENTS
        public event MacroEventHandler macroEventHandler;
        #endregion

        #region CONSTANTS
        private const string ctrlV = "^v";
        #endregion

        public void Main_Closing(object sender, CancelEventArgs e)
        {
            Unsubscribe();
        }

        public void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_GlobalHook = events;
            m_GlobalHook.KeyUp += OnKeyUp;
        }

        private void Unsubscribe()
        {
            if (m_GlobalHook == null) return;

            m_GlobalHook.Dispose();
            m_GlobalHook = null;
        }

        /// <summary>
        /// Controls when the key up event is fired up and treats it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyUp(object sender, WindowsHook.KeyEventArgs e)
        {
            // If it's '&' key and it hasn't been pressed before, the user might be starting to write the name of a macro.
            if (e.Shift && e.KeyCode == WindowsHook.Keys.D6 && !pressedAndpersand)
            {
                pressedAndpersand = true;
            }
            // If it's '#' and '&' has been pressed before, the used has written the name of a macro.
            else if (e.Alt && e.KeyCode == WindowsHook.Keys.D3 && pressedAndpersand && !string.IsNullOrWhiteSpace(macroName))
            {
                SetMacro();
            }
            // If the key number is between 'A' and 'Z', it belongs to the tag name.
            // TODO: The program should also accept numbers on the macro names.
            else if (e.KeyData >= WindowsHook.Keys.A && e.KeyData <= WindowsHook.Keys.Z && pressedAndpersand)
            {
                macroName += (char)e.KeyData;
            }
        }

        /// <summary>
        /// Sets up a macro to the clipboard and pastes it wherever the user is.
        /// </summary>
        private void SetMacro()
        {
            Macro macro = GetMacro();
            // Emits the event with the user search and if it has been found.
            MacroEventArgs args = new MacroEventArgs()
            {
                UserText = macroName,
                Found = false
            };
            if (macro != null)
            {
                CopyAndPasteMacro(macro, args);
            }
            macroEventHandler?.Invoke(null, args);
            // Reset the macroName.
            macroName = null;
            pressedAndpersand = false;
        }

        /// <summary>
        /// Copies and pastes the given macro.
        /// </summary>
        /// <param name="macro"></param>
        /// <param name="args"></param>
        private void CopyAndPasteMacro(Macro macro, MacroEventArgs args)
        {
            // Saves the current clipboard
            string clipboard = Clipboard.GetText();
            // Copies the text to the clipboard
            Clipboard.SetText(macro.Text);
            // Performs a manual paste of the clipboard
            System.Threading.Thread.Sleep(1000);
            SendKeys.Send(ctrlV);
            // Restores the clipboard
            Clipboard.SetText(clipboard);
            args.Found = true;
        }


        /// <summary>
        /// Returns the macro found with the given name on macroName.
        /// </summary>
        /// <returns></returns>
        private Macro GetMacro()
        {
            if (pressedAndpersand && !string.IsNullOrWhiteSpace(macroName))
            {
                AllTags allTags = JSONUtilities.Read();
                foreach (Tag tag in allTags.Tags)
                {
                    foreach (Macro macro in tag.Macros)
                    {
                        if (macro.Name.ToUpper().Trim().Equals(macroName.ToUpper().Trim()))
                        {
                            return macro;
                        }
                    }
                }
            }

            return null;
        }
    }
}

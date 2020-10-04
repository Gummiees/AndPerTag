using System;

namespace AndPerTag.Events
{
    public class MacroEventArgs : EventArgs
    {
        public bool Found { get; set; }
        public string UserText { get; set; }
    }
}
using System;

namespace AndPerTag.Events
{
    // FIXME: Revove this class and use default EventArgs. Create same class as this one to give it to "sender".
    public class MacroEventArgs : EventArgs
    {
        public bool Found { get; set; }
        public string UserText { get; set; }
    }
}
using AndPerTag.Models;

namespace AndPerTagCore.Models.Events
{
    public class EditMacroEvent
    {
        public Macro Original { get; set; }
        public EditMacro Created { get; set; }
    }
}
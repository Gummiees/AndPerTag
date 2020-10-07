using AndPerTag.Models;
using AndPerTagCore.Models;

namespace AndPerTagCore.Events
{
    public class EditMacroEvent
    {
        public Macro Original { get; set; }
        public EditMacro Created { get; set; }
    }
}
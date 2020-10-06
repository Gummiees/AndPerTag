using AndPerTag.Models;

namespace AndPerTagCore.Models
{
    public class EditMacro
    {
        public Macro Macro { get; set; }

        // The tag that macro is assigned to
        public Tag Tag { get; set; }
    }
}
using AndPerTag.Models;

namespace AndPerTagCore.Models.Events
{
    public class EditTagEvent
    {
        public Tag Original { get; set; }
        public Tag Created { get; set; }
    }
}
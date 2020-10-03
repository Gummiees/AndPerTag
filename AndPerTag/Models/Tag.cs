using System.Collections.Generic;

namespace AndPerTag.Models
{
    public class Tag
    {
        public string Name { get; set; }
        public List<Macro> Macros { get; set; }
    }
}

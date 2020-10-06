namespace AndPerTagCore.Models.Events
{
    public class EditEvent<T>
    {
        public T original { get; set; }
        public T created { get; set; }
    }
}
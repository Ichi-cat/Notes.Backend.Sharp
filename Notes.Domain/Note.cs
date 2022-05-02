using System;

namespace Notes.Domain
{
    public class Note
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Category Category { get; set; }
        public Guid? CategoryId { get; set; }
    }
}

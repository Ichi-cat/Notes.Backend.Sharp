using System;
using System.Collections.Generic;

namespace Notes.Domain
{
    public class Category
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
        public string Color { get; set; }
    }
}

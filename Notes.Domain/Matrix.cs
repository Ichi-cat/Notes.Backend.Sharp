using System;

namespace Notes.Domain
{
    public class Matrix
    {
        public MatricesEnum Id { get; set; }
        public string Name { get; set; }
    }
}

public enum MatricesEnum : byte
{
    ImportantUrgent = 1,
    ImportantNotUrgent,
    NotImportantUrgent,
    NotImportantNotUrgent

}
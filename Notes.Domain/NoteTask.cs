using System;

namespace Notes.Domain
{
    public class NoteTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Seconds { get; set; }
        public DateTime Date { get; set; }
        public Matrix Matrix { get; set; }
        public ProgressCondition ProgressCondition { get; set; }
        public Guid MatrixId { get; set; }
        public Guid ProgressConditionId { get; set; }
    }
}

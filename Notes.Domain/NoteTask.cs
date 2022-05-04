using System;

namespace Notes.Domain
{
    public class NoteTask
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Seconds { get; set; }
        public DateTime? Date { get; set; }
        public Matrix Matrix { get; set; }
        public ProgressCondition ProgressCondition { get; set; }
        public MatricesEnum? MatrixId { get; set; }
        public ProgressConditionEnum? ProgressConditionId { get; set; }
    }
}

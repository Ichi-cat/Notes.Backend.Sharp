using System;

namespace Notes.Domain
{
    public class ProgressCondition
    {
        public ProgressConditionEnum Id { get; set; }
        public string Name { get; set; }
    }
    public enum ProgressConditionEnum : byte
    {
        Planned = 1,
        During = 2,
        Ready = 3
    }
}

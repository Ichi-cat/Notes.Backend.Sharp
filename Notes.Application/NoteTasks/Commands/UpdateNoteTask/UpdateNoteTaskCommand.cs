﻿using MediatR;
using System;

namespace Notes.Application.NoteTasks.Commands.UpdateNoteTask
{
    public class UpdateNoteTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Seconds { get; set; }
        public DateTime? DateTime { get; set; }//
        public int? MatrixId { get; set; }//
        public int? ProgressConditionId { get; set; }
    }
}

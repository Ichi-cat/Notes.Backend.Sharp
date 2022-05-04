using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.ProgressConditions.Queries
{
    public class ProgressConditionDto : IMapWith<ProgressCondition>
    {
        public ProgressConditionEnum Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProgressCondition, ProgressConditionDto>();
        }
    }
}
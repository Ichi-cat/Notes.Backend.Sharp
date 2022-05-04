using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.Matrices.Queries.GetMatrixList
{
    public class MatrixDto : IMapWith<Matrix>
    {
        public MatricesEnum Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Matrix, MatrixDto>();
        }
    }
}
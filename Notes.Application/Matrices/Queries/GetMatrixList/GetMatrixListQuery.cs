using MediatR;
using System;

namespace Notes.Application.Matrices.Queries.GetMatrixList
{
    public class GetMatrixListQuery : IRequest<MatrixListDto>
    {
        public Guid UserId { get; set; }
    }
}

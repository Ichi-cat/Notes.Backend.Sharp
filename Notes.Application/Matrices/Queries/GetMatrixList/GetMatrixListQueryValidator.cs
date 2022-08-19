using FluentValidation;
using System;

namespace Notes.Application.Matrices.Queries.GetMatrixList
{
    public class GetMatrixListQueryValidator : AbstractValidator<GetMatrixListQuery>
    {
        public GetMatrixListQueryValidator()
        {
            RuleFor(getMatrixListQuery => getMatrixListQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}

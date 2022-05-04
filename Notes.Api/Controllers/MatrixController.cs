using Microsoft.AspNetCore.Mvc;
using Notes.Application.Matrices.Queries.GetMatrixList;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class MatrixController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MatrixListDto>> Get()
        {
            var query = new GetMatrixListQuery
            {
                UserId = UserId
            };
            var matrices = await Mediator.Send(query);
            return Ok(matrices);
        }
    }
}

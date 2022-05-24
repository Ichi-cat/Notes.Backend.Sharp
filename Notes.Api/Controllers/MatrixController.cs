using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Matrices.Queries.GetMatrixList;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class MatrixController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult<MatrixListDto>> GetMatrices()
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

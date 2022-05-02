using Microsoft.AspNetCore.Mvc;
using Notes.Application.Matrices.Queries.GetMatrixList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class MatrixController : BaseController
    {
        public async Task<ActionResult> Get()
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.ProgressConditions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class ProgressConditionController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult<ProgressConditionListDto>> GetProgressConditions()
        {
            var command = new GetProgressConditionListQuery();
            var progressConditions = await Mediator.Send(command);
            return Ok(progressConditions);
        }
    }
}

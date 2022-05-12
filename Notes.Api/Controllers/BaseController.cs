using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace Notes.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    [Produces("application/json")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected Guid UserId => User.Identity.IsAuthenticated ? Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) 
            : Guid.Empty;
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private IMapper _mapper;
        protected IMapper Mapper =>
            _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}

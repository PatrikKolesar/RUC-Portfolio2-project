using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Queries;
using IMDB.Application.Services.v1.TitlesService.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*
        // GET api/<UsersController/title/<tconst>>
        [HttpGet("title")]
        public async Task<ActionResult<ResponseMessage>> ViewTitle(string tconst)
        {
            try
            {
                return await _mediator.Send(new GetAllTitleQuer());
            }
            catch (Exception)
            {
                throw;
            }
        }
        */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<TitleBasic>> Get()
        {
            return await _mediator.Send(new GetTitleQuery());
        }
    }
}

using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.TitleService;
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

        // GET api/<TitlesController/id>
        [HttpGet("{tconst}")]
        public async Task<ActionResult<ResponseMessage>> GetTitle(string tconst)
            {
                try
                {
                    return await _mediator.Send(new CreateTitleCommand { Tconst = tconst });
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    
}
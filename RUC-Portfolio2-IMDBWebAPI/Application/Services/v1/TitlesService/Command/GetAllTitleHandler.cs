using Domain.Entities;
using IMDB.Application.Interfaces.v1.Repositories;
using IMDB.Application.Queries;
using IMDB.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitlesService.Command
{
    public class GetAllTitleHandler : IRequestHandler<GetTitleQuery, List<TitleBasic>>
    {
        private readonly ITitleRepository _titleRepo;

        public GetAllTitleHandler(ITitleRepository titleRepository)
        {
            _titleRepo = titleRepository;
        }
        public async Task<List<TitleBasic>> Handle(GetTitleQuery request, CancellationToken cancellationToken)
        {
            return (List<TitleBasic>)await _titleRepo.GetAllAsync();
        }
    }
}

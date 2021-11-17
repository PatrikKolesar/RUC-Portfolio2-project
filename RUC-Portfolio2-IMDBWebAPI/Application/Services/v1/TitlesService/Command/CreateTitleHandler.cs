using Domain.Entities;
using IMDB.Application.Mappers;
using IMDB.Application.Responses;
using IMDB.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitlesService.Command
{
    public class CreateTitleHandler : IRequestHandler<CreateTitleCommand, TitleResponse>
    {
        private readonly ITitleRepository _titleRepo;

        public CreateTitleHandler(ITitleRepository titleRepository)
        {
            _titleRepo = titleRepository;
        }
        public async Task<TitleResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            var titleEntitiy = TitleMapper.Mapper.Map<TitleBasic>(request);
            if (titleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newTitle = await _titleRepo.AddAsync(titleEntitiy);
            var titleResponse = TitleMapper.Mapper.Map<TitleResponse>(newTitle);
            return titleResponse;
        }
    }
}


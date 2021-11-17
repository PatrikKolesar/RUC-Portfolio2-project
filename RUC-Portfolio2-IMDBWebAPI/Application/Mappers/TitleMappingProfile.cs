using AutoMapper;
using Domain.Entities;
using IMDB.Application.Responses;
using IMDB.Application.Services.v1.TitlesService.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Application.Mappers
{
    public class TitleMappingProfile : Profile
    {
        public TitleMappingProfile()
        {
            CreateMap<TitleBasic, TitleResponse>().ReverseMap();
            CreateMap<TitleBasic, CreateTitleCommand>().ReverseMap();
        }
    }
}

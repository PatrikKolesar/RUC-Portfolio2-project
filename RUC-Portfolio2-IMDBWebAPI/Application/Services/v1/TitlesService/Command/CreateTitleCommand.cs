using System;
using System.Collections.Generic;
using System.Text;
using IMDB.Application.Responses;
using MediatR;

namespace IMDB.Application.Services.v1.TitlesService.Command
{
    public class CreateTitleCommand : IRequest<TitleResponse>
    {
        public string? Tconst { get; set; }
        public string? Titletype { get; set; }
        public string? Primarytitle { get; set; }
        public string? Originaltitle { get; set; }
        public bool? Isadult { get; set; }
        public string? Startyear { get; set; }
        public string? Endyear { get; set; }
        public int? Runtimeminutes { get; set; }
    }
}

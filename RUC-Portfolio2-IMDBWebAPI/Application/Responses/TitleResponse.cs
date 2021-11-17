using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Application.Responses
{
    public class TitleResponse
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
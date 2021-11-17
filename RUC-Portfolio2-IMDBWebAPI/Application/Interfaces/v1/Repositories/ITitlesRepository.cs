using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IMDB.Application.DTOs;

namespace IMDB.Application.Interfaces.v1.Repositories
{
    public interface ITitlesRepository
    {
        public Task<ResponseMessage> ViewTitle(TitleDTO tconst);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Application.Interfaces.v1.Repositories;
using IMDB.Application.DTOs;
using Infrastructure.Context;
using IMDB.Infrastructure.Repositories.v1.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using IMDB.Domain.Repositories;

namespace IMDB.Infrastructure.Repositories.v1.AuthService
{
    public class TitleRepository : Repository<TitleBasic>, ITitleRepository
    {
        public TitleRepository(imdbContext imdbContext) : base(imdbContext)
        {

        }
        public async Task<IEnumerable<TitleBasic>> GetTitleByConst(string tconst)
        {
            return await _imdbContext.TitleBasics
                .Where(m => m.Tconst == tconst)
                .ToListAsync();
        }
    }
}
using Domain.Entities;
using IMDB.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain.Repositories
{
    public interface ITitleRepository : IRepository<TitleBasic>
    {
        //custom operations here
        Task<IEnumerable<TitleBasic>> GetTitleByConst(string tconst);
    }
}

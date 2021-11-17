using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Application.Queries
{
    public class GetTitleQuery: IRequest<List<TitleBasic>>
    {
    }
}

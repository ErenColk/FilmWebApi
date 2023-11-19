using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Abstract
{
    public  interface IFilmService : IBaseService<Film>
    {

        List<Film> TGetFilmInclude(Expression<Func<Film, bool>> exp = null);

    }
}

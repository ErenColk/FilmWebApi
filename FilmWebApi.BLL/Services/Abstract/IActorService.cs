using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Abstract
{
    public interface IActorService : IBaseService<Actor>
    {

        List<Actor> TGetActorInclude(Expression<Func<Actor, bool>> exp = null);
        List<ResultActorWithFilmDTO> TGetActorFilmAndCategory(List<ResultActorWithFilmDTO> resultActorWithFilm);

        Actor TGetByActor(int id = 0, Expression<Func<Actor, object>> exp = null);

    }
}

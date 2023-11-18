using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Abstract
{
    public interface IActorService : IBaseService<Actor>
    {

        List<Actor> TGetActorInclude();
        List<ResultActorWithFilmDTO> TGetActorFilmAndCategory(List<ResultActorWithFilmDTO> resultActorWithFilm);
    }
}

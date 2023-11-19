using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.BLL.DTO.FilmDTO;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Concrete
{
    public class ActorManager : BaseManager<Actor>, IActorService
    {
        private readonly IBaseRepository<Actor> _baseRepository;
        private readonly IActorRepository _actorRepository;

        public ActorManager(IBaseRepository<Actor> baseRepository, IActorRepository actorRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _actorRepository = actorRepository;
        }

        public Actor TGetByActor(int id = 0, Expression<Func<Actor, object>> exp = null)
        {
            if (id <= 0 && exp == null)
            {
                return null;
            }
            else if (id <= 0)
                return null;

            return _actorRepository.GetByActor(id, exp);            
        }

        public List<ResultActorWithFilmDTO> TGetActorFilmAndCategory(List<ResultActorWithFilmDTO> resultActorWithFilm)
        {
            foreach (var actor in resultActorWithFilm)
            {            
                foreach (var item in actor.Films)
                {

                    item.Categorys = item.Categorys.Select(x => new Category { Id = x.Id, Name = x.Name }).ToList();
                    item.Actors.Clear();
                }
            }

            return resultActorWithFilm;

        }

        public List<Actor> TGetActorInclude(Expression<Func<Actor, bool>> exp = null)
        {
            return _actorRepository.GetActorInclude(exp);
        }
    }
}

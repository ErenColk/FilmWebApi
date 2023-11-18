﻿using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.BLL.DTO.FilmDTO;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ResultActorWithFilmDTO> TGetActorFilmAndCategory(List<ResultActorWithFilmDTO> resultActorWithFilm)
        {
            foreach (var actor in resultActorWithFilm)
            {            
                foreach (var item in actor.Films)
                {
                      
                    item.Category.Films.Clear();
                    item.Actors.Clear();
                }
            }

            return resultActorWithFilm;

        }

        public List<Actor> TGetActorInclude()
        {
            return _actorRepository.GetActorInclude();
        }
    }
}

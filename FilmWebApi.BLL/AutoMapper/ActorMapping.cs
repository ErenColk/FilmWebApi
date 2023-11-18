using AutoMapper;
using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.AutoMapper
{
    public class ActorMapping : Profile
    {
        public ActorMapping()
        {
            CreateMap<ResultActorDTO,Actor >().ReverseMap();
            CreateMap<Actor, ResultActorWithFilmDTO>().ReverseMap();
            CreateMap<Actor, CreateActorDTO>().ReverseMap();
            CreateMap<Actor, UpdateActorDTO>().ReverseMap();

        }
    }
}

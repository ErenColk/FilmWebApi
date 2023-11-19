using AutoMapper;
using FilmWebApi.BLL.DTO.FilmDTO;
using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.AutoMapper
{
    public class FilmMapping : Profile
    {

        public FilmMapping()
        {
            CreateMap<Film,ResultFilmDTO>().ReverseMap();
            CreateMap<Film,CreateFilmDTO>().ReverseMap();
            CreateMap<Film,UpdateFilmDTO>().ReverseMap();
            CreateMap<Film,ResultFilmWithCategoryActorDTO>().ReverseMap();
            CreateMap<Film,CreateFilmActorCategoryDTO>().ReverseMap();

        }
    }
}

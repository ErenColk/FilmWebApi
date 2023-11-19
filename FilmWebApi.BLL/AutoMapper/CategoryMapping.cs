using AutoMapper;
using FilmWebApi.BLL.DTO.CategoryDTO;
using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.AutoMapper
{
    public class CategoryMapping : Profile
    {

        public CategoryMapping()
        {
            CreateMap<Category,ResultCategoryDTO>().ReverseMap();
            CreateMap<Category,ResultCategoryWithFilmsDTO>().ReverseMap();
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();

            
        }
    }
}

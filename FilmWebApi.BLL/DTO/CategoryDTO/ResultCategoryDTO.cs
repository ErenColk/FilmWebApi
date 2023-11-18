using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.DTO.CategoryDTO
{
    public class ResultCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Film> Films { get; set; }
    }
}

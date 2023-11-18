using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.DTO.FilmDTO
{
    public class CreateFilmDTO
    {
        public string Name { get; set; }
        public int Year { get; set; }        
        public string ActorId { get; set; }
        public List<Actor>? Actors { get; set; }
        public int CategoryId{ get; set; }
        public Category Category { get; set; }
    }
}

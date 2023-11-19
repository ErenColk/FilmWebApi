using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.Entities
{
    public class Film : BaseEntity
    {
        public Film()
        {
            Categorys = new List<Category>();
            Actors = new List<Actor>();
        }
        public int Year { get; set; }
        public List<Actor>? Actors { get; set; }
        public List<Category> Categorys { get; set; }
    }
}

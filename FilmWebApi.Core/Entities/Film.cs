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

		public int Year { get; set; }
		public List<Actor>? Actors { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
	}
}

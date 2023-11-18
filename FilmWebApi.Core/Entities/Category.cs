using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.Entities
{
	public class Category : BaseEntity
	{
        public Category()
        {
            Films = new List<Film>();
        }

        public List<Film>? Films { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.Entities
{
	public class Category : BaseEntity
	{
		public List<Film> Films { get; set; }
	}
}

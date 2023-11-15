using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.Entities
{
	public class Actor : BaseEntity
	{

		public DateTime BirthDate { get; set; }
		public List<Film> Films { get; set; }

	}
}

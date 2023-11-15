using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using FilmWebApi.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.DAL.Repositories
{
	public class FilmRepository : BaseRepository<Film>, IFilmRepository
	{
		private readonly AppDBContext _context;

		public FilmRepository(AppDBContext context) : base(context)
		{
			_context = context;
		}

	}
}

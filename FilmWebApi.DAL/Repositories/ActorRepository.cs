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
	public class ActorRepository : BaseRepository<Actor>, IActorRepository
	{
		private readonly AppDBContext _context;

		public ActorRepository(AppDBContext context) : base(context)
		{
			_context = context;
		}


	}
}

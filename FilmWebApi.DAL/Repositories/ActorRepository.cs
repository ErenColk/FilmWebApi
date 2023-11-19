using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using FilmWebApi.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<Actor> GetActorInclude(Expression<Func<Actor, bool>> exp = null)
        {
            if (exp == null)
			return _context.Actors.Include(x => x.Films).ThenInclude(x=>x.Categorys).ToList();
            else
			return _context.Actors.Where(exp).Include(x => x.Films).ThenInclude(x=>x.Categorys).ToList();

        }

        public Actor GetByActor(int id = 0,Expression<Func<Actor,object>> exp = null)
        {
            if (exp == null && id > 0)
                return _context.Actors.Include(x => x.Films).FirstOrDefault(x => x.Id == id);
            else if (exp != null && id <= 0)
                return _context.Actors.Include(exp).FirstOrDefault();
            else if (exp != null && id > 0)
                return _context.Actors.Include(exp).FirstOrDefault(x => x.Id == id);
            else
                return null;



        }
    }
}

using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.IRepositories
{
	public interface IActorRepository : IBaseRepository<Actor>
	{
        List<Actor> GetActorInclude();

        Actor GetByActor(int id = 0, Expression<Func<Actor, object>>  exp = null);

    }
}

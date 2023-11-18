using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Concrete
{
    public class ActorManager : BaseManager<Actor>, IActorService
    {
        private readonly IBaseRepository<Actor> _baseRepository;

        public ActorManager(IBaseRepository<Actor> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }




    }
}

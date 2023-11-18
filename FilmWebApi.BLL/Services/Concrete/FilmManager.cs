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
    public class FilmManager : BaseManager<Film>, IFilmService
    {
        private readonly IBaseRepository<Film> _baseRepository;

        public FilmManager(IBaseRepository<Film> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }



    }
}

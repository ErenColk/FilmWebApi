using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using FilmWebApi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Concrete
{
    public class FilmManager : BaseManager<Film>, IFilmService
    {
        private readonly IBaseRepository<Film> _baseRepository;
        private readonly IFilmRepository _filmRepository;

        public FilmManager(IBaseRepository<Film> baseRepository,IFilmRepository filmRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _filmRepository = filmRepository;
        }

        public List<Film> TGetFilmInclude(Expression<Func<Film, bool>> exp = null)
        {
            return _filmRepository.GetFilmInclude(exp);
        }
    }
}

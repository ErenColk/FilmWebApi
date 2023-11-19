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
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        private readonly AppDBContext _context;

        public FilmRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Film> GetFilmInclude(Expression<Func<Film, bool>> exp = null)
        {
        
            if (exp == null)
                return _context.Films.Include(x => x.Categorys)
                    .Include(x => x.Actors)
                    .Select(film => new Film
                    {
                        Name = film.Name,
                        Year = film.Year,
                        Id = film.Id,

                        Actors = film.Actors.Select(actor => new Actor
                        {
                            Name = actor.Name,
                            LastName = actor.LastName,
                            BirthDate = actor.BirthDate,
                            Id = actor.Id
                        }).ToList(),
                        Categorys = film.Categorys.Select(cat => new Category
                        {
                            Id = cat.Id,
                            Name = cat.Name
                        }).ToList()

                    }).ToList();
            else
            {
                return _context.Films.Where(exp).Include(x => x.Categorys)
                 .Include(x => x.Actors)
                 .Select(film => new Film
                 {
                     Name = film.Name,
                     Year = film.Year,
                     Id = film.Id,

                     Actors = film.Actors.Select(actor => new Actor
                     {
                         Name = actor.Name,
                         LastName = actor.LastName,
                         BirthDate = actor.BirthDate,
                         Id = actor.Id
                     }).ToList(),
                     Categorys = film.Categorys.Select(cat => new Category
                     {
                         Id = cat.Id,
                         Name = cat.Name
                     }).ToList()

                 }).ToList();
            }
        }
    }
}

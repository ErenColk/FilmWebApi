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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetCategoriesInclude(Expression<Func<Category, bool>> exp = null)
        {
            if (exp == null)
            {
                var categories = _context.Categories.Include(x => x.Films).ToList();

                foreach (var item in categories)
                {
                    item.Films = item.Films.Select(x => new Film { Name = x.Name, Year = x.Year}).ToList();
                }

                return categories;

            }
            else
            {
                return _context.Categories.Where(exp).Include(x => x.Films).ToList();
            }



        }
    }
}

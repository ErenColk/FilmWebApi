using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Concrete
{
    public class CategoryManager : BaseManager<Category>, ICategoryService
    {
        private readonly IBaseRepository<Category> _baseRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(IBaseRepository<Category> baseRepository,ICategoryRepository categoryRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategoriesInclude(Expression<Func<Category, bool>> exp = null)
        {
            
                return _categoryRepository.GetCategoriesInclude(exp);
        
        }
    }
}

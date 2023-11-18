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
    public class CategoryManager : BaseManager<Category>, ICategoryService
    {
        private readonly IBaseRepository<Category> _baseRepository;

        public CategoryManager(IBaseRepository<Category> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }


    }
}

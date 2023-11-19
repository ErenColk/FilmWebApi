using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Abstract
{
    public interface ICategoryService : IBaseService<Category>
    {

        List<Category> GetCategoriesInclude(Expression<Func<Category, bool>> exp = null);
    }
}

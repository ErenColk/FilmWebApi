﻿using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.IRepositories
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
        List<Category> GetCategoriesInclude(Expression<Func<Category, bool>> exp = null);
    }
}

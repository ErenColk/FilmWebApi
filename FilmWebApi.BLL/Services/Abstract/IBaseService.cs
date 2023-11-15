using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Abstract
{
	public interface IBaseService<T> where T : BaseEntity
	{
		List<T> GetAll();
		T GetById(int id);
		T Add(T entity);
		T Update(T entity);
		bool Delete(T entity);
		T GetByWhere(Expression<Func<T, bool>> exp);
		List<T> GetWhere(Expression<Func<T, bool>> exp);

	}
}

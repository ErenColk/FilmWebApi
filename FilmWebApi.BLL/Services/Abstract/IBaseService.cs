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
		List<T> TGetAll();
		T TGetById(int id);
		bool TAdd(T entity);
		bool TUpdate(T entity);
		bool TDelete(int id);
		T TGetByWhere(Expression<Func<T, bool>> exp);
		List<T> TGetWhere(Expression<Func<T, bool>> exp);

	}
}

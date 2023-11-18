using FilmWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.Core.IRepositories
{
	public interface IBaseRepository<T> where T : BaseEntity 
	{
		List<T> GetAll();
		T GetById(int id);
		bool Add(T entity);
		bool Update(T entity);
		bool Delete(int id);
		T GetByWhere(Expression<Func<T, bool>> exp);
		bool Save();
		List<T> GetWhere(Expression<Func<T, bool>> exp);
	}
}

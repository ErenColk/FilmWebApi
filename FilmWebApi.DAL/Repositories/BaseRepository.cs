using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using FilmWebApi.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.DAL.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		private readonly AppDBContext _context;

		public BaseRepository(AppDBContext context)
        {
			_context = context;
		}

        public bool Add(T entity)
		{
			_context.Set<T>().Add(entity);
			
			return Save();
		}

		public bool Delete(int id)
		{
			_context.Set<T>().Remove(GetById(id));
			return Save();
		}

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);

		}

		public T GetByWhere(Expression<Func<T, bool>> exp)
		{
			return _context.Set<T>().Where(exp).FirstOrDefault();
		}

		public List<T> GetWhere(Expression<Func<T, bool>> exp)
		{

			return _context.Set<T>().Where(exp).ToList();
		}

		public bool Save()
		{
			return _context.SaveChanges() > 0;
		}

		public bool Update(T entity)
		{
			_context.Set<T>().Update(entity);
			
			return Save();
		}
	}
}

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

        public T Add(T entity)
		{
			_context.Set<T>().Add(entity);
			Save();
			return entity;
		}

		public bool Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
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

		public T Update(T entity)
		{
			_context.Set<T>().Update(entity);
			Save();
			return entity;
		}
	}
}

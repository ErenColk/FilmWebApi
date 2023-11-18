using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using FilmWebApi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.BLL.Services.Concrete
{
    public class BaseManager<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool TAdd(T entity)
        {
            try
            {
                if(entity == null)
                {
                    throw new Exception("İlgili veri bulunamadı.");
                }
                else
                {
                    return _baseRepository.Add(entity);
                }           
            }
            catch (Exception)
            {              
                throw ;
            }

        }

        public bool TDelete(int id)
        {
            if(id > 0)
            {
                
            return _baseRepository.Delete(id);
            }
            else
            { return false; }

        }

        public List<T> TGetAll()
        {
            return _baseRepository.GetAll();
        }

        public T TGetById(int id)
        {                  
            return _baseRepository.GetById(id);                     
        }

        public T TGetByWhere(Expression<Func<T, bool>> exp)
        {
            return _baseRepository.GetByWhere(exp);
        }

        public List<T> TGetWhere(Expression<Func<T, bool>> exp)
        {
           return _baseRepository.GetWhere(exp);
        }

        public bool TUpdate(T entity)
        {
            if(entity == null)
            {
                return false;
            }
            else
            {
                return _baseRepository.Update(entity);
            }

        }
    }
}

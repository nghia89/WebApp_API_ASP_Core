using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Data.EF
{
	public interface IRepository<T, K> where T : class
	{

		void Add(T entity);

		//T Add(T t);

		Task<T> AddAsyn(T t);

		int Count();

		Task<int> CountAsync();

		void Delete(T entity);

		Task<int> DeleteAsyn(T entity);

		void Dispose();

		T Find(Expression<Func<T,bool>> match);

		ICollection<T> FindAll(Expression<Func<T,bool>> match,params Expression<Func<T,object>>[] includeProperties);

		Task<ICollection<T>> FindAllAsync(Expression<Func<T,bool>> match,params Expression<Func<T,object>>[] includeProperties);

		IQueryable<T> GetAll(params Expression<Func<T,object>>[] includeProperties);

		Task<ICollection<T>> GetAllAsyn(params Expression<Func<T,object>>[] includeProperties);

		//IQueryable<T> GetAllIncluding(params Expression<Func<T,object>>[] includeProperties);

		T GetBy(int id);

		Task<T> GetABysync(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		T GetAByIdinclude(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		T FindBy(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		Task<T> FindByAsyn(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		void Save();

		Task<int> SaveAsync();

		T Update(T t,object key);

		Task<T> UpdateAsyn(T t,object key);
	}
}

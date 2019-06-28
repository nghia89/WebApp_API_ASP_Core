using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.interfaces
{
	public interface IRepository<T> where T : class
	{
		void Add(T entity);

		//T Add(T t);

		Task<T> AddAsyn(T t);

		long Count();

		Task<long> CountAsync();

		void Delete(T entity);

		Task<long> DeleteAsyn(T entity);

		void Dispose();

		T Find(Expression<Func<T,bool>> match);

		ICollection<T> FindAll(Expression<Func<T,bool>> match,params Expression<Func<T,object>>[] includeProperties);

		Task<ICollection<T>> FindAllAsync(Expression<Func<T,bool>> match,params Expression<Func<T,object>>[] includeProperties);

		IQueryable<T> GetAll(params Expression<Func<T,object>>[] includeProperties);

		Task<ICollection<T>> GetAllAsyn(params Expression<Func<T,object>>[] includeProperties);

		//IQueryable<T> GetAllIncluding(params Expression<Func<T,object>>[] includeProperties);

		T GetBy(long id);

		Task<T> GetABysync(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		T GetAByIdInclude(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		Task<T> GetAByIdIncludeAsyn(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		T FindBy(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		Task<T> FindByAsyn(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		Task<(ICollection<T>, long count)> Paging(int page,int pageSize,Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);

		void Save();

		Task<long> SaveAsync();

		T Update(T t,object key);

		Task<T> UpdateAsyn(T t,object key);
	}
}

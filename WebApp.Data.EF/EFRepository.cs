using Infrastructure.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApp.Data.EF
{
	public class EFRepository<T>:IRepository<T> where T : class
	{
		private readonly DBContext _context;
		private IUnitOfWork _unitOfWork;
		public EFRepository(DBContext context,IUnitOfWork unitOfWork)
		{
			this._context = context;
			this._unitOfWork = unitOfWork;
		}

		public async Task<T> FindSingle(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}

			var model = await items.Where(predicate).SingleOrDefaultAsync();
			return model;
		}

		public IQueryable<T> GetAll(params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items;
		}

		public async Task<ICollection<T>> GetAllAsyn(params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return await items.ToListAsync();
		}

		public T GetBy(long id)
		{
			return _context.Set<T>().Find(id);
		}

		public T FindBy(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(predicate).FirstOrDefault();
		}

		public async Task<T> FindByAsyn(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return await items.Where(predicate).FirstOrDefaultAsync();
		}

		public void Add(T entity)
		{
			_context.Add(entity);
			_unitOfWork.Commit();
		}

		//public  T Add(T t)
		//{

		//	_context.Set<T>().Add(t);
		//	_context.SaveChanges();
		//	return t;
		//}

		public async Task<T> AddAsyn(T t)
		{
			_context.Set<T>().Add(t);
			await _context.SaveChangesAsync();
			return t;

		}

		public ICollection<T> FindAll(Expression<Func<T,bool>> match,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(match).ToList();
		}

		public async Task<ICollection<T>> FindAllAsync(Expression<Func<T,bool>> match,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(Expression<Func<T,object>> includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return await items.Where(match).ToListAsync();
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		}

		public async Task<long> DeleteAsyn(T entity)
		{
			_context.Set<T>().Remove(entity);
			return await _context.SaveChangesAsync();
		}

		public T Update(T t,object key)
		{
			if(t == null)
				return null;
			T exist = _context.Set<T>().Find(key);
			if(exist != null)
			{
				_context.Entry(exist).CurrentValues.SetValues(t);
				_unitOfWork.Commit();
			}
			return exist;
		}

		public async Task<T> UpdateAsyn(T t,object key)
		{
			if(t == null)
				return null;
			T exist = await _context.Set<T>().FindAsync(key);
			if(exist != null)
			{
				_context.Entry(exist).CurrentValues.SetValues(t);
				await _context.SaveChangesAsync();
			}
			return exist;
		}

		public long Count()
		{
			return _context.Set<T>().Count();
		}

		public async Task<long> CountAsync()
		{
			return await _context.Set<T>().CountAsync();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public async Task<long> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}

		//public IQueryable<T> GetAllIncluding(params Expression<Func<T,object>>[] includeProperties)
		//{

		//	IQueryable<T> queryable = GetAll();
		//	foreach(Expression<Func<T,object>> includeProperty in includeProperties)
		//	{

		//		queryable = queryable.Include<T,object>(includeProperty);
		//	}

		//	return queryable;
		//}

		private bool disposed = false;
		protected void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
					_context.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public T Find(Expression<Func<T,bool>> match)
		{
			return _context.Set<T>().SingleOrDefault(match);
		}

		public async Task<T> FindAsync(Expression<Func<T,bool>> match)
		{
			return await _context.Set<T>().SingleOrDefaultAsync(match);
		}

		public async Task<T> GetABysync(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return await items.Where(predicate).FirstOrDefaultAsync();
		}

		public T GetAByIdInclude(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(predicate).FirstOrDefault();
		}

		public async Task<(ICollection<T>, long count)> Paging(int page,int pageSize,Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			//var totalRow = _context.Set<T>().Where(predicate);
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			var data = items.Where(predicate);
			var skip = (page - 1) * pageSize;
			var dataPaging = await data.Skip(skip)
								  .Take(pageSize)
								  .ToListAsync();

			return (dataPaging, data.Count());
		}

		public async Task<T> GetAByIdIncludeAsyn(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if(includeProperties != null)
			{
				foreach(var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return await items.Where(predicate).FirstOrDefaultAsync();
		}
	}
}

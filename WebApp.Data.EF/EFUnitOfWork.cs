using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF
{
	public class EFUnitOfWork:IUnitOfWork
	{
		private readonly DBContext _context;
		public EFUnitOfWork(DBContext context)
		{
			_context = context;
		}
		public void Commit()
		{
			_context.SaveChanges();
		}

		//public void Dispose()
		//{
		//	_context.Dispose();
		//}
	}
}

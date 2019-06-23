using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}

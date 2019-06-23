using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.interfaces
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}

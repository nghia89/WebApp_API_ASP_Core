using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.interfaces
{
	public interface IDateTracking
	{
		DateTime DateCreated { set; get; }

		DateTime? DateModified { set; get; }
	}
}

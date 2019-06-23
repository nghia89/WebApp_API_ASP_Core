using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.EF.Enums;

namespace WebApp.Data.EF.interfaces
{
public	interface ISwitchable
	{
		Status Status { get; set; }
	}
}

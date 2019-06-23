using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.Entities
{
	public class Tag
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}
}

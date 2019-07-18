using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.Entities
{
	public class ProductTag
	{
		public long Id { get; set; }
		public long? ProductId { get; set; }
		public string TagId { set; get; }
		public  Product Product { set; get; }
		public  Tag Tag { set; get; }
	}
}

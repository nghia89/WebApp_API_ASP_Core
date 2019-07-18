using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.EF.Enums;
using WebApp.Data.EF.interfaces;

namespace WebApp.Data.EF.Entities
{
	public class ProductCategory:IDateTracking, ISwitchable
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int? ParentId { get; set; }
		public int? HomeOrder { get; set; }
		public string Image { get; set; }
		public bool? HomeFlag { get; set; }
		public string SeoPageTitle { set; get; }
		public string SeoAlias { set; get; }
		public string SeoKeywords { set; get; }
		public string SeoDescription { set; get; }
		public int SortOrder { set; get; }
		public List<Product> Products { set; get; }
		public long? ProductId { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public Status Status { get; set; }
	}
}

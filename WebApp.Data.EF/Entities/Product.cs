using System;
using System.Collections.Generic;
using WebApp.Data.EF.Enums;
using WebApp.Data.EF.interfaces;

namespace WebApp.Data.EF.Entities
{
	public class Product:IDateTracking, ISwitchable
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }
		public double? PromotionPrice { get; set; }
		public double? OriginalPrice { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public bool? HomeFlag { get; set; }
		public bool? HotFlag { get; set; }
		public int? ViewCount { get; set; }
		public string Tags { get; set; }
		public string Unit { get; set; }
		public ProductCategory ProductCategory { set; get; }
		public long? ProductCategoryId { get; set; }
		public List<ProductTag> ProductTags { set; get; }
		public long? ProductTagId { get; set; }
		public string SeoPageTitle { set; get; }
		public string SeoAlias { set; get; }
		public string SeoKeywords { set; get; }
		public string SeoDescription { set; get; }
		public Status Status { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
	}
}

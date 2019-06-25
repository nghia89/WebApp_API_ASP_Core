using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Business.Model;
using WebApp.Data.EF.Entities;

namespace WebApp.Business.Mappers
{
	public class ProductMapperProfile:Profile
	{
		public ProductMapperProfile()
		{
			CreateMap<Product,ProductModel>().ReverseMap();
		}
	}
	public static class ProductMapper
	{
		internal static IMapper Mapper { get; }

		static ProductMapper()
		{
			Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductMapperProfile>())
			   .CreateMapper();
		}

		public static ProductModel ToModel(this Product product)
		{
			return Mapper.Map<ProductModel>(product);
		}
	}
}

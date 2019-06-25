using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Business.interfaces;
using WebApp.Business.Mappers;
using WebApp.Business.Model;
using WebApp.Data.EF;
using WebApp.Data.EF.Entities;
using WebApp.Repository.interfaces;

namespace WebApp.Business.Implementation
{
	public class ProductBusiness:IProductBusiness
	{
		private readonly DBContext _dBContext;
		private IProductRepository _productRepository;

		public ProductBusiness(DBContext dBContext,IProductRepository productRepository)
		{
			this._dBContext = dBContext;
			this._productRepository = productRepository;

		}
		public async Task<ProductModel> Add(ProductModel model)
		{
			Product product = new Product {
				Name = model.Name,
				Content = model.Content,
				DateCreated = DateTime.UtcNow.AddHours(7),
				DateModified = DateTime.UtcNow.AddHours(7),
				Description = model.Description,
				HomeFlag = model.HomeFlag,
				HotFlag = model.HotFlag,
				Image = model.Image,
				OriginalPrice = model.OriginalPrice,
				Price = model.Price,
				ProductCategoryId = model.ProductCategoryId,
				ProductTagId = model.ProductTagId,
				PromotionPrice = model.PromotionPrice,
				SeoAlias = model.SeoAlias,
				SeoDescription = model.SeoDescription,
				SeoKeywords = model.SeoKeywords,
				SeoPageTitle = model.SeoPageTitle,
				Status = model.Status
			};
			var data = await _productRepository.Add(product);
			return data.ToModel();
		}

		public async Task<List<ProductModel>> GetAll()
		{
			var listAll =await _productRepository.GetAllAsyn();
			return listAll.Select(a=>a.ToModel()).ToList();
		}

		public async Task<ProductModel> GetById(long id)
		{
			var data = await _productRepository.GetById(id);
			return data.ToModel();
		}

		public Task<List<ProductModel>> Paging(int page,int pageSize)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductModel> Update(ProductModel model)
		{
			Product product = new Product {
				Name = model.Name,
				Content = model.Content,
				DateCreated = DateTime.UtcNow.AddHours(7),
				DateModified = DateTime.UtcNow.AddHours(7),
				Description = model.Description,
				HomeFlag = model.HomeFlag,
				HotFlag = model.HotFlag,
				Image = model.Image,
				OriginalPrice = model.OriginalPrice,
				Price = model.Price,
				ProductCategoryId = model.ProductCategoryId,
				ProductTagId = model.ProductTagId,
				PromotionPrice = model.PromotionPrice,
				SeoAlias = model.SeoAlias,
				SeoDescription = model.SeoDescription,
				SeoKeywords = model.SeoKeywords,
				SeoPageTitle = model.SeoPageTitle,
				Status = model.Status
			};
			var data = await _productRepository.Update(product);
			return data.ToModel();
		}
	}
}

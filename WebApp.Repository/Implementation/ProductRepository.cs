using Infrastructure.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.EF;
using WebApp.Data.EF.Entities;
using WebApp.Data.EF.Enums;
using WebApp.Repository.interfaces;

namespace WebApp.Repository.Implementation
{
	public class ProductRepository:IProductRepository
	{
		private IRepository<Product> _productRepository;
		private IUnitOfWork _unitOfWork;
		private DBContext _dBContext;
		public ProductRepository(IRepository<Product> productRepository,IUnitOfWork unitOfWork,DBContext dBContext)
		{
			this._productRepository = productRepository;
			this._unitOfWork = unitOfWork;
			this._dBContext = dBContext;
		}

		public async Task<Product> Add(Product model)
		{
			var data= await _productRepository.AddAsyn(model);
			return data;
		}

		public async Task<long> DeleteAsyn(long id)
		{
			return await _productRepository.DeleteAsyn(_productRepository.GetBy(id));
		}

		public async Task<Product> FindByAsyn(long id)
		{
			var getbyId = await _productRepository.GetABysync(x => x.Id == id);
			return getbyId;
		}

		public async Task<List<Product>> GetAllAsyn()
		{
			var data = await _productRepository.GetAllAsyn(x => x.ProductCategory);
			return data.ToList();
		}

		public async Task<Product> GetById(long id)
		{
			var data = await _productRepository.GetAByIdIncludeAsyn(x => x.Id == id);
			return data;
		}

		public async Task<(List<Product> data, long totalCount)> Paging(int page,int page_size)
		{
			var (data, totalRow) = await _productRepository.Paging(page,page_size,x => x.Status == Status.Active,
					new Expression<Func<Product,object>>[] { a => a.ProductCategory }
				);
			return (data.ToList(), totalRow);
		}

		public async Task<Product> Update(Product model)
		{
			return await _productRepository.UpdateAsyn(model,model.Id);
		}
	}
}

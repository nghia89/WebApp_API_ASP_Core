using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.EF.Entities;

namespace WebApp.Repository.interfaces
{
	public interface IProductRepository
	{
		Task<Product> Add(Product model);
		Task<List<Product>> GetAllAsyn();
		Task<Product> Update(Product model);
		Task<long> DeleteAsyn(long id);
		Task<Product> GetById(long id);
		Task<Product> FindByAsyn(long id);
		Task<(List<Product> data, long totalCount)> Paging(int page,int page_size);
	}
}

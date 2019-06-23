using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Business.Model;

namespace WebApp.Business.interfaces
{
	public interface IProductBusiness
	{
		Task<ProductModel> Add(ProductModel model);
		Task<ProductModel> Update(ProductModel product);
		Task<ProductModel> GetById(long id);
		Task<List<ProductModel>> GetAll();
		Task<List<ProductModel>> Paging(int page,int pageSize);
	}
}

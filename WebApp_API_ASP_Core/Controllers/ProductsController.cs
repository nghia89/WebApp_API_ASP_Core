using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApp.Business.interfaces;
using WebApp.Business.Model;
using WebApp.Data.EF.Entities;
using WebApp_API_ASP_Core.Extensions;
using WebApp_API_ASP_Core.Model;

namespace WebApp_API_ASP_Core.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductBusiness _productBusiness;
        public ProductsController(IProductBusiness productBusiness)
        {
            this._productBusiness = productBusiness;
        }
        // GET: api/Products
        [HttpGet]
        [Route("product/getAll")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var data = await _productBusiness.GetAll();
            var dataResult = data.Select(x => ProductViewModel.from(x)).ToList();
            return  new JsonResult(dataResult);

        }
        // POST: api/Products

        [HttpPost]
        [Route("product")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> add([FromBody]ProductViewModel model)
        {
            var product = new ProductModel()
            {
                Name = model.Name,
                Content = model.Content,
                DateCreated = DateTime.UtcNow.AddHours(7).Date,
                Description = model.Description,
                HomeFlag = model.HomeFlag,
                HotFlag = model.HotFlag,
                Image = model.Image,
                OriginalPrice = model.OriginalPrice,
                Price = model.Price,
                ProductCategoryId = model.ProductCategoryId,
                Tags = model.Tags,
                SeoAlias = model.SeoAlias,
                SeoDescription = model.SeoDescription,
                SeoKeywords = model.SeoKeywords,
                SeoPageTitle = model.SeoPageTitle,
                Status = model.Status

            };

            ProductModel data = await _productBusiness.Add(product);
            return new OkObjectResult(data);
        }
    }
}

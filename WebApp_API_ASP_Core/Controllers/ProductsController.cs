﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Business.interfaces;
using WebApp.Business.Model;
using WebApp_API_ASP_Core.Extensions;

namespace WebApp_API_ASP_Core.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[MiddlewareFilter(typeof(LocalizationPipeline))]
	public class ProductsController : ControllerBase
    {
		private readonly IProductBusiness _productBusiness;
		public ProductsController(IProductBusiness productBusiness)
		{
			this._productBusiness = productBusiness;
		}
        // GET: api/Products
        [HttpGet]
        public async  Task<IActionResult> Get()
        {
			var data=await _productBusiness.GetAll();
			return new OkObjectResult(data);

		}
        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interface;
using Shop.Domain.Model;

namespace Shop.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductService service)
        {
            ProductService = service;            
        }

        private IProductService ProductService { get; }


        [HttpGet]
        public IActionResult GetProducts([FromQuery] Guid catalogueId)
        {
            var products = ProductService.GetProducts(catalogueId);
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProduct(Guid productId)
        {
            var product = ProductService.GetProduct(productId);

            if(product == null)
                return NotFound(productId);

            return Ok(product);
        }

    }
}

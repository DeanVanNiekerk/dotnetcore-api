using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Controllers;
using Shop.Api.Test.Mocks;
using Shop.Domain.Model;
using Xunit;

namespace Shop.Api.Test
{
    public class ProductionsControllerTest
    {
        [Fact]
        public void GetProducts()
        {
            //Given: some products
            var catalogueId = Guid.NewGuid();

            var p1 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Golf Clubs",
                CatalogueId = catalogueId,
                CatalogueName = "Sports"
            };

            var p2 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Soccer Ball",
                CatalogueId = catalogueId,
                CatalogueName = "Sports"
            };

            var mockService = new MockShopService(new List<Product> { p1, p2 });

            //When:
            var controller = new ProductsController(mockService);
            var result = controller.GetProducts(catalogueId);

            //Then:
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Product>>(okResult.Value);

            Assert.Same(mockService.Products, returnValue);
        }

        [Fact]
        public void GetProduct()
        {
            //Given: a product
            var p1 = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Golf Clubs",
                CatalogueId = Guid.NewGuid(),
                CatalogueName = "Sports"
            };

            var mockService = new MockShopService(new List<Product> { p1 });

            //When:
            var controller = new ProductsController(mockService);
            var result = controller.GetProduct(p1.Id);

            //Then:
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Product>(okResult.Value);

            Assert.Same(p1, returnValue);
        }

        [Fact]
        public void GetProduct_NotFound()
        {
            //Given: no product
            var mockService = new MockShopService(new List<Product>());

            //When:
            var productId = Guid.NewGuid();
            var controller = new ProductsController(mockService);
            var result = controller.GetProduct(productId);

            //Then:
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(productId, notFoundObjectResult.Value);
        }
    }
}

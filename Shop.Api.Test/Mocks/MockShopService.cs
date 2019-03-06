using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Interface;
using Shop.Domain.Model;

namespace Shop.Api.Test.Mocks
{
    public class MockShopService : IShopService
    {
        public MockShopService(List<Product> products)
        {
            Products = products;
        }

        public List<Product> Products { get; set; }

        public Product GetProduct(Guid productId)
        {
            return Products.FirstOrDefault();
        }

        public List<Product> GetProducts(Guid catalogueId)
        {
            return Products;
        }
    }
}
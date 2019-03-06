using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Domain.Model;

namespace Shop.Domain.Interface
{
    public interface IProductService
    {
        Product GetProduct(Guid productId);
        List<Product> GetProducts(Guid catalogueId);
    }
}
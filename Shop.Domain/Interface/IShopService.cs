using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Domain.Model;

namespace Shop.Domain.Interface
{
    public interface IShopService
    {
        Product GetProduct(Guid productId);
        List<Product> GetProducts(Guid catalogueId);
    }
}
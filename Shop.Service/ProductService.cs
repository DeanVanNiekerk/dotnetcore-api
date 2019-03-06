using System;
using System.Linq;
using System.Collections.Generic;
using Shop.Data;
using Shop.Domain.Interface;
using Shop.Domain.Model;

namespace Shop.Service
{
    public class ProductService : IProductService
    {
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        
        public Product GetProduct(Guid productId)
        {
             var query = from product in _context.Product
                        join catalogue in _context.Catalogue
                            on product.CatalogueId equals catalogue.Id
                        where product.Id == productId
                        select new Product()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            CatalogueId = product.CatalogueId,
                            CatalogueName = catalogue.Name
                        };

            return query.SingleOrDefault();
        }

        public List<Product> GetProducts(Guid catalogueId)
        {
            var query = from product in _context.Product
                        join catalogue in _context.Catalogue
                            on product.CatalogueId equals catalogue.Id
                        where product.CatalogueId == catalogueId
                        select new Product()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            CatalogueId = product.CatalogueId,
                            CatalogueName = catalogue.Name
                        };

            return query.ToList();
        }
    }
}

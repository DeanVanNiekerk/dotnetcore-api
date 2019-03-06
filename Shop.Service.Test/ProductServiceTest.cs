using System;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Xunit;
using Shop.Service;

namespace Shop.Service.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void GetProducts()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                            .UseInMemoryDatabase("GetProduct_Exists").Options;

            //Given
            var catalgue = new CatalogueEntity { Id = Guid.NewGuid(), Name = "Sports" };
            var product1 = new ProductEntity { Id = Guid.NewGuid(), Name = "Golf Clubs", CatalogueId = catalgue.Id };
            var product2 = new ProductEntity { Id = Guid.NewGuid(), Name = "Soccer Ball", CatalogueId = catalgue.Id };

            var product3 = new ProductEntity { Id = Guid.NewGuid(), Name = "Book", CatalogueId = Guid.NewGuid() };

            using (var context = new DataContext(options))
            {
                context.Catalogue.Add(catalgue);

                context.Product.Add(product1);
                context.Product.Add(product2);

                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                var service = new ProductService(context);

                //When
                var list = service.GetProducts(catalgue.Id);

                //Then
                Assert.Equal(2, list.Count);

                var actual1 = list[0];
                Assert.Equal(product1.Id, actual1.Id);
                Assert.Equal(product1.Name, actual1.Name);
                Assert.Equal(catalgue.Id, actual1.CatalogueId);
                Assert.Equal(catalgue.Name, actual1.CatalogueName);

                var actual2 = list[1];
                Assert.Equal(product2.Id, actual2.Id);
                Assert.Equal(product2.Name, actual2.Name);
                Assert.Equal(catalgue.Id, actual2.CatalogueId);
                Assert.Equal(catalgue.Name, actual2.CatalogueName);

            }
        }

        [Fact]
        public void GetProduct()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                            .UseInMemoryDatabase("GetProduct").Options;

            //Given
            var catalgue = new CatalogueEntity { Id = Guid.NewGuid(), Name = "Sports" };
            var product1 = new ProductEntity { Id = Guid.NewGuid(), Name = "Golf Clubs", CatalogueId = catalgue.Id };
            var product2 = new ProductEntity { Id = Guid.NewGuid() };

            using (var context = new DataContext(options))
            {
                context.Catalogue.Add(catalgue);
                
                context.Product.Add(product2);
                context.Product.Add(product1);

                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                var service = new ProductService(context);

                //When
                var actual = service.GetProduct(product1.Id);

                //Then
                Assert.Equal(product1.Id, actual.Id);
                Assert.Equal(product1.Name, actual.Name);
                Assert.Equal(catalgue.Id, actual.CatalogueId);
                Assert.Equal(catalgue.Name, actual.CatalogueName);
            }
        }
    }
}

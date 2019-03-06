using System;

namespace Shop.Domain.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CatalogueId { get; set; }
        public string Name { get; set; }

        public string CatalogueName { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Entities
{
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CatalogueId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual CatalogueEntity Catalogue { get; set; }
    }
}
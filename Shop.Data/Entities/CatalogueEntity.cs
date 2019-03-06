using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Entities
{
    public class CatalogueEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }

    }
}
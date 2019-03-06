using Microsoft.EntityFrameworkCore;
using Shop.Data.Entities;

namespace Shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<CatalogueEntity> Catalogue { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shop.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Shop;User ID=sa;Password=2x&%bLn3c47Y!y&hv7");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
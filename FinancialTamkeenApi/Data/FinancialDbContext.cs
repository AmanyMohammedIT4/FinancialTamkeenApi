using FinancialTamkeenApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FinancialTamkeenApi.Data
{
    public class FinancialDbContext:DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options)
        {

        }
        //DbSets
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Users> Employees { get; set; }
    }
}

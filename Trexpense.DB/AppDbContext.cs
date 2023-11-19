using Microsoft.EntityFrameworkCore;
using Trexpense.DB;

namespace Expenses.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        public DbSet<Expense> Expenses { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TrexpenseDb;Trusted_Connection=True;");
        }
    }
}

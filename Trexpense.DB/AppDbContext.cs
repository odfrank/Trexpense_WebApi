using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Trexpense.DB;

namespace Trexpense.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        public DbSet<Expense> Expenses { get; set; }
        //public DbSet<User> Users { get; set; }        
    }
}

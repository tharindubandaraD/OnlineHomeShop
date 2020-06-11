using HomeShop.API.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeShop.API.Data
{
    public class DataContext : DbContext
    {
        /* The dbContextOptions carries the configuration information needed to 
        configure the DbContext. The dbContextOptions can also be configured 
        using the OnConfiguring method. This method gets the 
        DbContextOptionsBuilder as its argument. It is then used to create the dbContextOptions*/
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Value> Values {get; set;}        
        public DbSet<User> Users {get; set;}
    }
}
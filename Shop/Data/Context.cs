using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }           
        public  DbSet<Custumer> Custumers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Usuario> Users { get; set; }

    }
}
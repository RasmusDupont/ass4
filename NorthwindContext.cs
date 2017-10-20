using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=localhost;database=northwind;uid=root;pwd=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryName");
            modelBuilder.Entity<OrderDetails>().HasKey(o => new { o.OrderId, o.ProductId });
        }
    }
}

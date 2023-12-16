using Microsoft.EntityFrameworkCore;

namespace P04_RelationDB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-M8KR7TQE;Database=TestProduct66;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //กำหนด Primary Key
            modelBuilder.Entity<ComponentProduct>().HasKey(k => new { k.ProductId, k.ComponentId });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ComponentProduct> ComponentProducts { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
    }
}

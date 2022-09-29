using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopDemo.Core.Data.Models;

namespace ShopDemo.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
    }
}
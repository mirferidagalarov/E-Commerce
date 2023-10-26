using e_commerce_.net5.Models.Entities;
using E_commerce_.NET5_.Models.Entities;
using E_commerce_.NET5_.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace e_commerce_.net5.Models.DataContext
{
    public class Dbcontext : IdentityDbContext<RiodeUser, RiodeRole, int, RiodeUserClaim, RiodeUserRole, RiodeUserLogin, RiodeRoleClaim, RiodeUserToken>
    {

        public Dbcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RiodeUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });
            builder.Entity<RiodeRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });
            builder.Entity<RiodeUserRole>(e =>
            {
                e.ToTable("UserRoles", "Membership");
            });
            builder.Entity<RiodeUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });
            builder.Entity<RiodeRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });
            builder.Entity<RiodeUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });
            builder.Entity<RiodeUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });

        }


        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSizeColorItem> productSizeColorCollection { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SpecificationCategoryItem> SpecificationCategoryCollection { get; set; }
        public DbSet<SpecificationValue> SpecificationValues { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }


    }
}

using e_commerce_.net5.Models.Entities;
using E_commerce_.NET5_.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace e_commerce_.net5.Models.DataContext
{
    public class Dbcontext:DbContext
    {

        public Dbcontext(DbContextOptions options):base(options)
        {

        }

      

       public DbSet<ContactPost> ContactPosts { get; set; }
       public DbSet<Brand>  Brands { get; set; }
        public DbSet<ProductColor>  ProductColors { get; set; }
        public DbSet<ProductSize>  ProductSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSizeColorItem>  productSizeColorCollection { get; set; }
        public DbSet<Specification>  Specifications { get; set; }
        public DbSet<SpecificationCategoryItem>  SpecificationCategoryCollection { get; set; }
        public DbSet<SpecificationValue> SpecificationValues { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Subscribe>  Subscribes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }


    }
}

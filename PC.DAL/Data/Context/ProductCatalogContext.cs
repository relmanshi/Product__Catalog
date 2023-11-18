using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DAL;

public class ProductCatalogContext:IdentityDbContext<User>
{
    public DbSet<User> User => Set<User>();
    public DbSet<Products> Products=>Set<Products>();
    public DbSet<Categories> Categories => Set<Categories>();

    public ProductCatalogContext(DbContextOptions options): base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Categories
        builder.Entity<Categories>(entity=>{
            entity.HasKey(c => c.CategoryId);
            entity.Property(c => c.CategoryName).IsRequired();
        });
        #endregion

        #region Products
        builder.Entity<Products>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Products>>)(entity =>
        {
            entity.HasKey(c => c.ProductId);
            entity.Property<string>(c=> c.ProductName).IsRequired();
            entity.Property(c => c.price).IsRequired();
            entity.Property(c => c.StartDate).IsRequired();
            entity.Property(c => c.duration).IsRequired();
            
            entity.HasOne<User>(c=> c.User)
            .WithMany(c=> c.Products)
            .HasForeignKey(c=> c.createdBy);

            entity.HasOne<Categories>(c => c.Categories)
            .WithMany((System.Linq.Expressions.Expression<Func<Categories, IEnumerable<Products>?>>)(c => c.Products))
            .HasForeignKey(c => c.CategoryId);
        }));

        #endregion

        #region User
        builder.Entity<User>(entity =>
        {
            entity.Property(c=>c.FirstName).HasMaxLength(20).IsRequired();

            entity.Property(c=>c.LastName).HasMaxLength(20).IsRequired();

            entity.Property(c => c.Role).IsRequired();

            entity.Property(c => c.Email).IsRequired();
        });

        #endregion

        #region Category Seeding
        List<Categories> categoryList = new List<Categories>
        {
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Skin Care" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Makeup" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Appliances" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Furniture" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Footwear" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Toys" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Electronics" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Bags" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Scarves" },
            new Categories{ CategoryId=Guid.NewGuid(),CategoryName="Accessories" }


        };
                builder.Entity<Categories>().HasData(categoryList);

        #endregion
    }
}

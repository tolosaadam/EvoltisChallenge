using EvoltisChallenge.Api.Infraestructure.dbEntities;
using EvoltisChallenge.Api.Infraestructure.dbEntities.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.Repositories.Ef;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProductDb> Products => Set<ProductDb>();
    public DbSet<ProductCategoryDb> ProductCategories => Set<ProductCategoryDb>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<ProductDb>(entity =>
        {
            entity.ToTable("products");

            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Category)
                  .WithMany(pt => pt.Products)
                  .HasForeignKey(p => p.ProductCategoryId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired();

            entity.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(p => p.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(p => p.Price)
            .HasColumnName("price")
            .IsRequired();

            entity.Property(p => p.ProductCategoryId)
            .HasColumnName("product_category_id")
            .IsRequired();

            entity.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

            entity.Property(p => p.ModifiedAt)
            .HasColumnName("modified_at")
            .IsRequired();
        });

        modelBuilder.Entity<ProductCategoryDb>(entity =>
        {
            entity.ToTable("product_categories");

            entity.HasKey(pt => pt.Id);

            entity.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired();

            entity.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(p => p.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(100);
        });

        modelBuilder.Entity<ProductCategoryDb>().HasData(SeedDataConstants.ProductCategories);

        modelBuilder.Entity<ProductDb>().HasData(SeedDataConstants.Products);
    }
}

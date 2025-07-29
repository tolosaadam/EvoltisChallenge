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
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Category)
                  .WithMany(pt => pt.Products)
                  .HasForeignKey(p => p.ProductCategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ProductCategoryDb>(entity =>
        {
            entity.HasKey(pt => pt.Id);
        });

        modelBuilder.Entity<ProductCategoryDb>().HasData(SeedDataConstants.ProductCategories);

        modelBuilder.Entity<ProductDb>().HasData(SeedDataConstants.Products);
    }
}

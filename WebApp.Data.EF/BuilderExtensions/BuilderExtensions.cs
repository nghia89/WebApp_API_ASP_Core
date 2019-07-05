using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.EF.Entities;

namespace WebApp.Data.EF.BuilderExtensions
{
	public static class BuilderExtensions
	{
		public static void ConfigModelBuilder(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppUser>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			modelBuilder.Entity<AppRole>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserLogin<string>>(entity => {
				entity.Property(m => m.LoginProvider).HasMaxLength(127);
				entity.Property(m => m.ProviderKey).HasMaxLength(127);
			});
			modelBuilder.Entity<IdentityUserRole<string>>(entity => {
				entity.Property(m => m.UserId).HasMaxLength(127);
				entity.Property(m => m.RoleId).HasMaxLength(127);
			});
			modelBuilder.Entity<IdentityUserToken<string>>(entity => {
				entity.Property(m => m.UserId).HasMaxLength(127);
				entity.Property(m => m.LoginProvider).HasMaxLength(127);
				entity.Property(m => m.Name).HasMaxLength(127);

			});

			modelBuilder.Entity<Product>(entity => {
				entity.ToTable(nameof(Product));
				entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
				entity.HasIndex(x => x.Id).IsUnique();
				entity.HasIndex(x=>x.Name).ForMySqlIsFullText(true);
			});

			modelBuilder.Entity<ProductCategory>(entity => {
				entity.ToTable(nameof(ProductCategory));
				entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
				entity.HasIndex(x => x.Id).IsUnique();
				entity.HasIndex(x => x.Name).ForMySqlIsFullText(true);
				entity.HasMany(a => a.Products).WithOne(b => b.ProductCategory).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<ProductTag>(entity => {
				entity.ToTable(nameof(ProductTag));
				entity.HasIndex(x => x.Id).IsUnique();
			});

			modelBuilder.Entity<Tag>(entity => {
				entity.ToTable(nameof(Tag));
				entity.HasIndex(x => x.Id).IsUnique();
			});
		
		}
	}
}

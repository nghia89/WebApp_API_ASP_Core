

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using WebApp.Data.EF.Entities;
using WebApp.Data.EF.interfaces;

namespace WebApp.Data.EF
{
	public class DBContext:IdentityDbContext<AppUser>
	{
		
		public DBContext(DbContextOptions<DBContext> options):base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
		
			builder.Entity<AppUser>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			builder.Entity<AppRole>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			builder.Entity<IdentityUserLogin<string>>(entity => {
				entity.Property(m => m.LoginProvider).HasMaxLength(127);
				entity.Property(m => m.ProviderKey).HasMaxLength(127);
			});
			builder.Entity<IdentityUserRole<string>>(entity => {
				entity.Property(m => m.UserId).HasMaxLength(127);
				entity.Property(m => m.RoleId).HasMaxLength(127);
			});
			builder.Entity<IdentityUserToken<string>>(entity => {
				entity.Property(m => m.UserId).HasMaxLength(127);
				entity.Property(m => m.LoginProvider).HasMaxLength(127);
				entity.Property(m => m.Name).HasMaxLength(127);

			});
			base.OnModelCreating(builder);
		}

		public DbSet<AppRole> appRoles { get; set; }
		public DbSet<AppUser> appUsers { get; set; }
		public DbSet<Product> products { get; set; }
		public DbSet<ProductCategory> productCategories { get; set; }
		public DbSet<ProductTag> productTags { get; set; }
		public DbSet<Tag> tags { get; set; }

		

		public override int SaveChanges()
		{
			var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

			foreach(EntityEntry item in modified)
			{
				var changedOrAddedItem = item.Entity as IDateTracking;
				if(changedOrAddedItem != null)
				{
					if(item.State == EntityState.Added)
					{
						changedOrAddedItem.DateCreated = DateTime.UtcNow.AddHours(7).Date;
					}
					changedOrAddedItem.DateModified = DateTime.UtcNow.AddHours(7).Date;
				}
			}
			return base.SaveChanges();
		}
	}
}

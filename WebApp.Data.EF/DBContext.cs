

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using WebApp.Data.EF.BuilderExtensions;
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
			builder.ConfigModelBuilder();
			base.OnModelCreating(builder);
		}

		public DbSet<AppRole> AppRoles { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductTag> ProductTags { get; set; }
		public DbSet<Tag> Tags { get; set; }

		

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

	public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<DBContext>
	{
		public DBContext CreateDbContext(string[] args)
		{
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json").Build();
			var builder = new DbContextOptionsBuilder<DBContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			builder.UseMySql(connectionString);
			return new DBContext(builder.Options);
		}
	}
}

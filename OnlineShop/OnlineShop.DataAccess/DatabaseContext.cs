using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Manufacturer> Manufacturers { get; set; }

		public DbSet<ProductStock> ProductStocks { get; set; }

		public virtual DbSet<SiteUser> SiteUsers { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DatabaseContext(string connectionString) : base(GetOptions(connectionString))
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("SiteIdentityUserClaim").HasKey(p => new { p.Id });
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("SiteIdentityUserToken").HasKey(p => new { p.UserId });
		}

		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}

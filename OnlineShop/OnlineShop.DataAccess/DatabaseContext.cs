using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.DataAccess;

namespace OnlineShop.DataAccess
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DatabaseContext(string connectionString) : base(GetOptions(connectionString))
		{
			Database.EnsureCreated();
		}

		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}

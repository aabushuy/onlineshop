using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.Entities;

namespace OnlineShop.DataAccess
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}
	}
}

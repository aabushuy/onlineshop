using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;

namespace OnlineShop.DataAccess.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}

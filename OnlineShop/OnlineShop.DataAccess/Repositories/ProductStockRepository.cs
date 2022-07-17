using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;

namespace OnlineShop.DataAccess.Repositories
{
	public class ProductStockRepository : GenericRepository<ProductStock>, IProductStockRepository
	{
		public ProductStockRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}

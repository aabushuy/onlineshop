using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;

namespace OnlineShop.DataAccess.Repositories
{
	public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
	{
		public ManufacturerRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}

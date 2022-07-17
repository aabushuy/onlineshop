using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;

namespace OnlineShop.DataAccess.Repositories
{
	public class SiteUserRepository : GenericRepository<SiteUser>, ISiteUserRepository
	{
		public SiteUserRepository(DatabaseContext context) : base(context)
		{
		}
	}
}

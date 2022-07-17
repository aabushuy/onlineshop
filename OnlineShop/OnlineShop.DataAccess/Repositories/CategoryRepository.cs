using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;

namespace OnlineShop.DataAccess.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}

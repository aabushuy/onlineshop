using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DbContext _databaseContext;

		public GenericRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<IList<T>> GetAllAsync()
		{
			return await _databaseContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> selector)
		{
#pragma warning disable CS8603 // Possible null reference return.
			return await _databaseContext.Set<T>().Where(selector).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
		}

		public async Task<T> CreateAsync(T entity)
		{
			await _databaseContext.AddAsync(entity);
			await _databaseContext.SaveChangesAsync();

			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_databaseContext.Update(entity);
			await _databaseContext.SaveChangesAsync();

			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_databaseContext.Remove(entity);
			await _databaseContext.SaveChangesAsync();
		}
	}
}

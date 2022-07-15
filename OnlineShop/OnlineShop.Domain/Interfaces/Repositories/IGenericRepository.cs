using System.Linq.Expressions;

namespace OnlineShop.Domain.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IList<T>> GetAllAsync();

		Task<T> GetAsync(Expression<Func<T, bool>> selector);

		Task<T> CreateAsync(T entity);

		Task<T> UpdateAsync(T entity);

		Task DeleteAsync(T entity);
	}
}

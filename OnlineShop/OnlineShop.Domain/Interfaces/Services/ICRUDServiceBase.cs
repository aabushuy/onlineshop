namespace OnlineShop.Domain.Interfaces.Services
{
	public interface ICRUDServiceBase<T> where T : class
	{
		Task<IList<T>> GetAllAsync();

		Task<T?> GetAsync(int id);

		Task<T> AddAsync(T item);

		Task<T> UpdateAsync(T item);

		Task DeleteAsync(T item);
	}
}

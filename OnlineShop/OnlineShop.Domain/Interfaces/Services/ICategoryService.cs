using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces.Services
{
	public interface ICategoryService
	{
		Task<IList<CategoryDto>> GetAllAsync();

		Task<CategoryDto?> GetAsync(int id);

		Task<CategoryDto> AddAsync(CategoryDto category);

		Task<CategoryDto> UpdateAsync(CategoryDto category);

		Task DeleteAsync(CategoryDto category);
	}
}

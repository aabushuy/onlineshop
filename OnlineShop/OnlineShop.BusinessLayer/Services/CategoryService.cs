using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;

namespace OnlineShop.BusinessLayer.Services
{
	public class CategoryService : ServiceBase, ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(
			IMapper mapper,
			ICategoryRepository categoryRepository) : base(mapper)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IList<Category>> GetAllAsync()
		{
			return await _categoryRepository.GetAllAsync();
		}

		public async Task<Category?> GetAsync(int id)
		{
			return await _categoryRepository.GetAsync(c => c.Id == id);
		}

		public async Task<Category> AddAsync(Category category)
		{
			var isUniq = !(await _categoryRepository.GetAllAsync()).Any(c => c.Name == category.Name);
			if (!isUniq) 
			{
				throw new InvalidOperationException($"The {category.Name} already exists");
			}

			return await _categoryRepository.CreateAsync(category);
		}

		public async Task<Category> UpdateAsync(Category category)
		{
			return await _categoryRepository.UpdateAsync(category);
		}

		public async Task DeleteAsync(Category category)
		{
			await _categoryRepository.DeleteAsync(category);
		}
	}
}

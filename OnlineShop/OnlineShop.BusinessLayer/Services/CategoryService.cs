using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<IList<CategoryDto>> GetAllAsync()
		{
			var categories = new List<CategoryDto>();
			foreach (var category in await _categoryRepository.GetAllAsync())
			{
				var categoryDto = _mapper.Map<CategoryDto>(category);
				categories.Add(categoryDto);
			}

			return categories;
		}

		public async Task<CategoryDto?> GetAsync(int id)
		{
			var category = await _categoryRepository.GetAsync(c => c.Id == id);
			var categoryDto = _mapper.Map<CategoryDto>(category);

			categoryDto.Parent = category.ParentId.HasValue
				? _mapper.Map<CategoryDto>(await GetAsync(category.ParentId.Value))
				: null;

			return categoryDto;
		}

		public Task<CategoryDto> AddAsync(CategoryDto category)
		{
			throw new NotImplementedException();
		}

		public Task<CategoryDto> UpdateAsync(CategoryDto category)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(CategoryDto category)
		{
			throw new NotImplementedException();
		}
	}
}

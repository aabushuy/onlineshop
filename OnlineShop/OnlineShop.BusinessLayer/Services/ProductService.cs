using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;

namespace OnlineShop.BusinessLayer.Services
{
	public class ProductService : ServiceBase, IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IMapper mapper, IProductRepository productRepository) : base(mapper)
		{
			_productRepository = productRepository;
		}

		public async Task<IList<Product>> GetAllAsync()
		{
			return await _productRepository.GetAllAsync();
		}

		public async Task<Product?> GetAsync(int id)
		{
			return await _productRepository.GetAsync(c => c.Id == id);
		}

		public async Task<Product> AddAsync(Product item)
		{
			var isUniq = !(await _productRepository.GetAllAsync()).Any(c => c.Name == item.Name);
			if (!isUniq)
			{
				throw new InvalidOperationException($"The {item.Name} already exists");
			}

			return await _productRepository.CreateAsync(item);
		}

		public async Task<Product> UpdateAsync(Product item)
		{
			return await _productRepository.UpdateAsync(item);
		}

		public async Task DeleteAsync(Product item)
		{
			await _productRepository.DeleteAsync(item);
		}
	}
}

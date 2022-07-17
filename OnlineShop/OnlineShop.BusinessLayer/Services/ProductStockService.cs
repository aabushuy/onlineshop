using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;

namespace OnlineShop.BusinessLayer.Services
{
	public class ProductStockService : ServiceBase, IProductStockService
	{
		private readonly IProductStockRepository _productStockRepository;

		public ProductStockService(IMapper mapper, IProductStockRepository productStockRepository) : base(mapper)
		{
			_productStockRepository = productStockRepository;
		}

		public async Task<IList<ProductStock>> GetAllAsync()
		{
			return await _productStockRepository.GetAllAsync();
		}

		public async Task<ProductStock?> GetAsync(int id)
		{
			return await _productStockRepository.GetAsync(ps=> ps.ProductId == id);
		}

		public async Task<ProductStock> AddAsync(ProductStock item)
		{
			return await _productStockRepository.CreateAsync(item);
		}

		public async Task<ProductStock> UpdateAsync(ProductStock item)
		{
			return await _productStockRepository.UpdateAsync(item);
		}

		public async Task DeleteAsync(ProductStock item)
		{
			await _productStockRepository.DeleteAsync(item);
		}
	}
}

using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;

namespace OnlineShop.BusinessLayer.Services
{
	public class ManufacturerService : ServiceBase, IManufacturerService
	{
		private readonly IManufacturerRepository _manufacturerRepository;

		public ManufacturerService(IMapper mapper, IManufacturerRepository manufacturerRepository)
			: base(mapper)
		{
			_manufacturerRepository = manufacturerRepository;
		}

		public async Task<IList<Manufacturer>> GetAllAsync()
		{
			return await _manufacturerRepository.GetAllAsync();
		}

		public async Task<Manufacturer?> GetAsync(int id)
		{
			return await _manufacturerRepository.GetAsync(c => c.Id == id);
		}

		public async Task<Manufacturer> AddAsync(Manufacturer item)
		{
			throw new NotImplementedException();
		}

		public async Task<Manufacturer> UpdateAsync(Manufacturer item)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteAsync(Manufacturer item)
		{
			throw new NotImplementedException();
		}
	}
}

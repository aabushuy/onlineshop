using AutoMapper;

namespace OnlineShop.BusinessLayer.Services
{
	public abstract class ServiceBase
	{
		protected readonly IMapper _mapper;

		public ServiceBase(IMapper mapper)
		{
			_mapper = mapper;
		}
	}
}

using OnlineShop.BusinessLayer.Services;
using OnlineShop.DataAccess.Repositories;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;

namespace OnlineShop
{
	public static class Infrastructure
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddRepositories();
			services.AddServices();
			services.AddBuilders();
			services.AddMapper();

			return services;
		}

		private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

			return services;
		}

		private static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICategoryService, CategoryService>();

			return services;
		}

		private static IServiceCollection AddBuilders(this IServiceCollection services)
		{
			
			return services;
		}

		private static IServiceCollection AddMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(
				typeof(BusinessLayer.Profiles.CategoryProfile),
				typeof(Profiles.CategoryModelProfile));

			return services;
		}
	}
}

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
			services.AddMapper();

			return services;
		}

		private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
			services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
			services.AddScoped(typeof(IManufacturerRepository), typeof(ManufacturerRepository));
			services.AddScoped(typeof(IProductStockRepository), typeof(ProductStockRepository));

			services.AddScoped(typeof(ISiteUserRepository), typeof(SiteUserRepository));

			return services;
		}

		private static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IManufacturerService, ManufacturerService>();
			services.AddScoped<IProductStockService, ProductStockService>();

			services.AddTransient<IBreadcrumbService, BreadcrumbService>();
			services.AddTransient<ISiteUserService, SiteUserService>();

			return services;
		}

		private static IServiceCollection AddMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(
				typeof(Profiles.CategoryModelProfile),
				typeof(Profiles.ProductModelProfile));

			return services;
		}
	}
}

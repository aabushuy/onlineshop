using OnlineShop.Domain.Entities;
using System.Security.Claims;

namespace OnlineShop.Domain.Interfaces.Services
{
	public interface ISiteUserService
	{
		Task<SiteUser> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal);

		Task<SiteUser> GetUserByIdAsync(string id);

		Task<SiteUser> GetUserByEmailAsync(string email);
	}
}

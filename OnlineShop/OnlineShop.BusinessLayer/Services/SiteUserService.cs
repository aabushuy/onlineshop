using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces.Repositories;
using OnlineShop.Domain.Interfaces.Services;
using System.Security.Claims;

namespace OnlineShop.BusinessLayer.Services
{
	public class SiteUserService : ISiteUserService
	{
		private readonly ISiteUserRepository _siteUserRepository;

		public SiteUserService(ISiteUserRepository siteUserRepository)
		{
			_siteUserRepository = siteUserRepository;
		}

		public async Task<SiteUser> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal)
		{
			var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (userId != null)
			{
				return await GetUserByIdAsync(userId);
			}

			return default;
		}

		public async Task<SiteUser> GetUserByIdAsync(string id)
		{
			return await _siteUserRepository.GetAsync(u => u.Id == id);
		}

		public async Task<SiteUser> GetUserByEmailAsync(string email)
		{
			return await _siteUserRepository.GetAsync(u => u.Email == email);
		}
	}
}

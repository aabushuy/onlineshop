using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Domain.Entities
{
	public class SiteUser : IdentityUser
	{
		public SiteRole Role { get; set; } = SiteRole.User;
	}
}

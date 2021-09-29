using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByUserByClaimsPricipleEmailAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.FindFirst(ClaimTypes.Email)?.Value;

            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.FindFirst(ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace P08_Authorization2.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<MyUser> userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<MyUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<List<IdentityRole>> Get()
        {
            return await roleManager.Roles.ToListAsync();
        }
    }
}

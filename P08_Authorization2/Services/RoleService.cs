using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P08_Authorization2.Models;

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

        public async Task<bool> Add(RoleDto roleDto)
        {
            var role = new IdentityRole
            {
                Name = roleDto.Name,
                NormalizedName = roleManager.NormalizeKey(roleDto.Name)
            };
            var result = await roleManager.CreateAsync(role);
            if(!result.Succeeded) { return false; }
            return true;
        }

        public async Task<bool> Delete(string name)
        {
            var role = await Find(name);
            if (role == null) return false;
            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded) { return false; }
            return true;
        }

        public async Task<IdentityRole> Find(string name)
        {
            return await roleManager.FindByNameAsync(name);
        }

        public async Task<List<IdentityRole>> Get()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<bool> Update(RoleUpdateDto roleUpdateDto)
        {
            var role = await Find(roleUpdateDto.Name);
            if (role == null) { return false; }
            role.Name = roleUpdateDto.NameUpdate;
            role.NormalizedName = roleManager.NormalizeKey(roleUpdateDto.NameUpdate);
            var result = await roleManager.UpdateAsync(role);
            if (!result.Succeeded) { return false; }
            return true;
        }
    }
}

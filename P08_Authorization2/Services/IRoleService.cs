using Microsoft.AspNetCore.Identity;
using P08_Authorization2.Models;

namespace P08_Authorization2.Services
{
    public interface IRoleService
    {
        Task<List<IdentityRole>> Get();
        Task<bool> Add(RoleDto roleDto);
        Task<bool> Delete(string name);
        Task<bool> Update(RoleUpdateDto roleUpdateDto);
        Task<IdentityRole> Find(string name);
    }
}

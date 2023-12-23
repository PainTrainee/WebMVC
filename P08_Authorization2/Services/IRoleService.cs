using Microsoft.AspNetCore.Identity;

namespace P08_Authorization2.Services
{
    public interface IRoleService
    {
        Task<List<IdentityRole>> Get();
    }
}

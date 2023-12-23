using Microsoft.AspNetCore.Mvc;
using P08_Authorization2.Services;

namespace P08_Authorization2.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

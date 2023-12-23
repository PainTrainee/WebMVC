using Microsoft.AspNetCore.Mvc;
using P08_Authorization2.Models;
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
        public async Task<IActionResult> Index()
        {
            var result = await roleService.Get();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleDto roleDto)
        {
            await roleService.Add(roleDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string name)
        {
            var result = await roleService.Find(name);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var roleUpdate = new RoleUpdateDto { Name = result.Name };
            return View(roleUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateDto roleUpdateDto)
        {
            await roleService.Update(roleUpdateDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(string name)
        {
            await roleService.Delete(name);
            return RedirectToAction(nameof(Index));
        }
    }
}
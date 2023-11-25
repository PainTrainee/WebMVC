using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>()
            {
                new Product() { Id=1,Name="Coffee",Price=100,Amount=25},
                new Product() { Id=2,Name="Coffee",Price=200,Amount=15},

            };
            return View(new {product,Title="Coffee Shop"});
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ClothesRentalShop.Controllers
{
    public class ClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

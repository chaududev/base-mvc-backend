using Microsoft.AspNetCore.Mvc;

namespace ClothesRentalShop.Controllers
{
    public class TypeClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

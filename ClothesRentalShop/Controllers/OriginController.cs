using Microsoft.AspNetCore.Mvc;

namespace ClothesRentalShop.Controllers
{
    public class OriginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

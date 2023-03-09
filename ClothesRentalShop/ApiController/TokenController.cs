using Application.Service.StaffServices;
using ClothesRentalShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ClothesRentalShop.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        readonly IStaffService StaffService;

        public TokenController(IStaffService StaffService)
        {
            this.StaffService = StaffService;
        }

        [HttpPost]
        public IActionResult Post(UserInfoViewModel StaffData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(StaffService.Token(StaffData.Email, StaffData.Password));
                }
                return UnprocessableEntity(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
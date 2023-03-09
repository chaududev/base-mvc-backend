using System.ComponentModel.DataAnnotations;

namespace ClothesRentalShop.ViewModel
{
    public class UserInfoViewModel
    {
        [EmailAddress(ErrorMessage = "You have to enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}


using Domain.Cloth;
using System.ComponentModel.DataAnnotations;

namespace ClothesRentalShop.ViewModel
{
    public class OriginViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public List<Clothes> Clothes { get; private set; } = new List<Clothes>();
    }
}

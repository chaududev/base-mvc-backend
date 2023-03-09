using Domain.Cloth;
using System.ComponentModel.DataAnnotations;

namespace ClothesRentalShop.ViewModel
{
    public class TypeClothesViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Limit has to be between 1 and 100")]
        public int Limit { get; set; }
        public List<Clothes> Clothes { get; private set; } = new List<Clothes>();
    }
}

using Domain.Cloth;
using Domain.Invoices;
using Domain.LaundryInvoices;
using System.ComponentModel.DataAnnotations;

namespace ClothesRentalShop.ViewModel
{
    public class ClothesViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [EnumDataType(typeof(Size), ErrorMessage = "Size must be between 0 and 3")]
        public Size Size { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        public int RentalTime { get; private set; }
        [Range(0, int.MaxValue, ErrorMessage = "RentalPrice must be greater than 0.")]
        public int RentalPrice { get; set; }
        public int TypeClothesId { get; set; }
        public int OriginId { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Status has to between 0 and 4")]
        public Status Status { get; set; }
        public List<DetailInvoice> DetailInvoices { get; private set; } = new List<DetailInvoice>();
        public List<DetailInvoiceLaundry> DetailInvoiceLaundries { get; private set; } = new List<DetailInvoiceLaundry>();
    }
}

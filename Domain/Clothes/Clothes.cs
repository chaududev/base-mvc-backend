
using Domain.Invoices;
using Domain.LaundryInvoices;
using System.Text.Json.Serialization;

namespace Domain.Cloth
{
    public enum Status
    {
        None,
        Available,
        Rental,
        NeedToSell,
        Sold
    }
    public enum Size
    {
        None,
        Small,
        Medium,
        Large
    }
    public class Clothes
    {
        private Clothes(){}
        public int Id { get; private set; }
        public string Name { get; private set; } 
        public string Description { get; private set; }
        public Size Size { get; private set; }
        public decimal Price { get; private set; }
        public int RentalTime { get; private set;}
        public int RentalPrice { get; private set; }
        public int TypeClothesId { get; private set; }
        public int OriginId { get; private set; }
        public Status Status { get; private set; }
        [JsonIgnore]
        public TypeClothes TypeClothes { get; private set; }
        [JsonIgnore]
        public Origin Origin { get; private set; }
        [JsonIgnore]
        public List<DetailInvoice> DetailInvoices { get; private set; } = new List<DetailInvoice>();
        [JsonIgnore]
        public List<DetailInvoiceLaundry> DetailInvoiceLaundries { get; private set; } = new List<DetailInvoiceLaundry>();

        public Clothes(string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, int originId, Status status)
        {
            RentalTime = 0;
            Update(name, description, size, price, rentalPrice, typeClothesId, originId, status);
        }
        public void Update(string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, int originId, Status status)
        {
            Name = name.Trim();
            Description = description.Trim();
            Size = size;
            Price = price>0?price:0;
            RentalPrice = rentalPrice>10000?rentalPrice:10000;
            TypeClothesId = typeClothesId;
            OriginId = originId;
            Status = status;
        }
        public void ChangeStatus(Status status)
        {
            if (this.Status != Status.Sold) Status = status;
        }
        public void ChangeRentalTime()
        {
            if (this.RentalTime < TypeClothes.Limit) this.RentalTime++;
            else this.ChangeStatus(Status.NeedToSell);
        }
    }
}
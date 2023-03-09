using Domain.Cloth;

namespace Domain.LaundryInvoices
{
    public class DetailInvoiceLaundry
    {
        public DetailInvoiceLaundry() { }
        public int Id { get; private set; }
        public int LaundryInvoiceId { get; private set; }
        public int ClothesId { get; private set; }
        public decimal Price { get; private set; }
        public LaundryInvoice LaundryInvoice { get; private set; }
        public Clothes Cloth { get; private set; }

        public DetailInvoiceLaundry(int laundryInvoiceId, int clothesId, decimal price)
        {
            if (Cloth.Status == Status.Available)
                Update(laundryInvoiceId,clothesId, price);
        }
        public void Update(int laundryInvoiceId, int clothesId, decimal price)
        {
            LaundryInvoiceId = laundryInvoiceId;
            ClothesId = clothesId;
            Price = price>0?price:0;
        }
    }
}


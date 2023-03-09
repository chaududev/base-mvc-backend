using Domain.Customers;
using Domain.Staffs;

namespace Domain.Invoices
{
    public class Invoice
    {
        public Invoice() { }
        public int Id { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public int CustomerId { get; private set; }
        public int StaffId { get; private set; }
        public int Discount { get; private set; } = 0;
        public Customer Customer { get; private set; }
        public Staff Staff { get; private set; }
        public List<DetailInvoice> DetailInvoices { get; private set; } = new List<DetailInvoice>();
        public Invoice(int customerId, int staffId, int discount)
        {
            Update(DateTime.Now,customerId, staffId, discount);
        }
        public void Update(DateTime date, int customerId, int staffId, int discount)
        {
            Date = date;
            CustomerId = customerId;
            StaffId = staffId;
            Discount = discount>0?discount:0;
        }
    }
}



using Domain.Invoices;
namespace Domain.Customers
{
    public class Customer
    {
        public Customer(){ }
        public int Id { get; private set; }
        public string FullName { get; private set; } 
        public string Phone { get; private set; } 
        public string Address { get; private set; } 
        public List<Invoice> Invoices { get; private set; } = new List<Invoice>();
        public Customer(string fullName, string phone, string address)
        {
            Update(fullName, phone, address);
        }
        public void Update(string fullName, string phone, string address)
        {
            FullName = fullName.Trim();
            Phone = phone.Trim();
            Address = address.Trim();
        }
    }
}


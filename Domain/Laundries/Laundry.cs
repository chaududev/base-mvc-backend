using Domain.LaundryInvoices;

namespace Domain.Laundries
{
    public class Laundry
    {
        public Laundry(){}
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; } 
        public string Address { get; private set; } 
        public int Rate { get; private set; }

        public List<LaundryInvoice> LaundryInvoices { get; private set; } = new List<LaundryInvoice>();

        public Laundry(string name, string phone, string address, int rate)
        {
            Update(name,phone, address, rate);  
        }
        public void Update(string name, string phone, string address, int rate)
        {
            Name = name.Trim();
            Phone = phone.Trim();
            Address = address.Trim();
            Rate = rate>0&&rate<=5?rate:1;
        }
    }
}

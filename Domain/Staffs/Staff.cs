
using Domain.Invoices;
using Domain.LaundryInvoices;
namespace Domain.Staffs
{
    public class Staff
    {
        public Staff() { }
        public int Id { get; private set; }
        public string CitizenCode { get; private set; } 
        public string FullName { get; private set; } 
        public DateTime Birthday { get; private set; }
        public string Phone { get; private set; } 
        public string Address { get; private set; } 
        public int RoleId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public RoleStaff RoleStaff { get; private set; }
        public List<Invoice> Invoices { get; private set; } = new List<Invoice>();
        public List<LaundryInvoice> LaundryInvoices { get; private set; } = new List<LaundryInvoice>();
        public Staff(string citizenCode, string fullName, DateTime birthday, string phone, string address, int roleId,string email, string password)
        {
            Update(citizenCode, fullName, birthday, phone, address, roleId, email, password);
            CreatedDate = DateTime.Now;
        }
        public void Update(string citizenCode, string fullName, DateTime birthday, string phone, string address, int roleId, string email, string password)
        {
            CitizenCode = citizenCode.Trim();
            FullName = fullName.Trim();
            Birthday = birthday;
            Phone = phone.Trim();
            Address = address.Trim();
            RoleId = roleId;
            Email= email.Trim(); 
            Password = password.Trim();
        }
    }
}

using Domain.Staffs;
using Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StaffRepository : IStaffRepository
    {
        public Staff GetStaff(string email, string password)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Staff.SingleOrDefault(u => u.Email == email && u.Password == password);
                return rs;
            }
        }
    }
}

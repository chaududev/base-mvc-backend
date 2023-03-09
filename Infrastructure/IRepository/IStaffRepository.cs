using Domain.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepository
{
    public interface IStaffRepository
    {
        Staff GetStaff(string email, string password);
    }
}

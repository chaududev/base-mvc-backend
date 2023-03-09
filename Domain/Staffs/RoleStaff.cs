
namespace Domain.Staffs
{
    public class RoleStaff
    {
        public RoleStaff(){ }
        public int Id { get; private set; }
        public string Name { get; private set; } 

        public List<Staff> Staffs { get; private set; } = new List<Staff>();

        public RoleStaff(string name)
        {
            Name = name.Trim();
        }
    }
}

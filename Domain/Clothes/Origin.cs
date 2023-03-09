
namespace Domain.Cloth
{
    public class Origin
    {
        public Origin(){}
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; } 

        public List<Clothes> Clothes { get; private set; } = new List<Clothes>();
        public Origin(string name, string address)
        {
            Update(name,address);
        }
        public void Update(string name, string address)
        {
            Name = name.Trim();
            Address = address.Trim();
        }
        
    }
}


using Domain.Cloth;
namespace Application.Service.ClothService
{
    public interface IClothesService
    {
        IEnumerable<Clothes> GetList(string? key, int? pageSize, int? page);
        Clothes GetById(int id);
        void Add(string name, string description, Size size, decimal price, int rentalPrice,int typeClothesId,int originId,Status status);
        void Update(int id, string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, int originId, Status status);
        void Delete(int id);
    }
}

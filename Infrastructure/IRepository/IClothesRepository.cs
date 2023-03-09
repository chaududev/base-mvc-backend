using Domain.Cloth;

namespace Infrastructure.IRepository
{
    public interface IClothesRepository
    {
        IEnumerable<Clothes> GetList(string? key, int? pageSize, int? page);
        Clothes GetById(int id);
        void Add(Clothes clothe);
        void Update(int id, Clothes clothe);
        void Delete(Clothes clothe);
    }
}

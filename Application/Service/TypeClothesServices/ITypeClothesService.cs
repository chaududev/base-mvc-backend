using Domain.Cloth;

namespace Application.Service.TypeClothService
{
    public interface ITypeClothesService
    {
        IEnumerable<TypeClothes> GetList(string? key, int? pageSize,int? page);
        TypeClothes GetById(int id);
        void Add(string name,int limit);
        void Update(int id, string name, int limit);
        void Delete(int id);
    }
}

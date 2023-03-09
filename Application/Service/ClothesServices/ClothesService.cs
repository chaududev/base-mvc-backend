
using Domain.Cloth;
using Infrastructure.IRepository;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web.Http;

namespace Application.Service.ClothService
{
    public class ClothesService : IClothesService
    {
        readonly IClothesRepository clothesRepository;
        readonly IOriginRepository originRepository;
        readonly ITypeClothesRepository typeClothesRepository;

        public ClothesService(IClothesRepository clothesRepository, IOriginRepository originRepository, ITypeClothesRepository typeClothesRepository)
        {
            this.clothesRepository = clothesRepository;
            this.originRepository = originRepository;
            this.typeClothesRepository = typeClothesRepository;
        }

        public void Add(string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, int originId, Status status)
        {
            if (originRepository.GetById(originId) == null)
            {
                throw new Exception($"The specified foreign key Origin with ID {originId} was not found.");
            }
            if (typeClothesRepository.GetById(typeClothesId) == null)
            {
                throw new Exception($"The specified foreign key TypeClothes with ID {typeClothesId} was not found.");
            }
            Clothes cloth = new Clothes(name, description, size, price, rentalPrice, typeClothesId, originId, status);
            clothesRepository.Add(cloth);
        }

        public void Delete(int id)
        {
            var clothe = clothesRepository.GetById(id);
            if (clothe == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            clothesRepository.Delete(clothe);
        }

        public Clothes GetById(int id)
        {
            return clothesRepository.GetById(id);
        }

        public IEnumerable<Clothes> GetList(string? key, int? pageSize, int? page)
        {
            return clothesRepository.GetList(key,pageSize??int.MaxValue, page??1);
        }
        public void Update(int id, string name, string description, Size size, decimal price, int rentalPrice, int typeClothesId, int originId, Status status)
        {
            var ClothesBefore = clothesRepository.GetById(id);
            if (ClothesBefore == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            if (originRepository.GetById(originId) == null)
            {
                throw new Exception($"The specified foreign key Origin with ID {originId} was not found.");
            }
            if (typeClothesRepository.GetById(typeClothesId) == null)
            {
                throw new Exception($"The specified foreign key TypeClothes with ID {typeClothesId} was not found.");
            }
           Clothes cloth = new Clothes(name, description, size, price, rentalPrice, typeClothesId, originId, status);
           clothesRepository.Update(id, cloth);
        }
    }
}

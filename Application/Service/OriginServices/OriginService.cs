using Domain.Cloth;
using Infrastructure.IRepository;

namespace Application.Service.OriginsService
{
    public class OriginService : IOriginService
    {
        readonly IOriginRepository originRepository;

        public OriginService(IOriginRepository _originRepository)
        {
            this.originRepository = _originRepository;
        }

        public void Add(string name,string address)
        {
            Origin Origin = new Origin(name,address);
            originRepository.Add(Origin);
        }

        public void Delete(int id)
        {
            Origin clothe = originRepository.GetById(id);
            if (clothe == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            originRepository.Delete(clothe);
        }
        public void Update(int id, string name, string address)
        {
            Origin clothe = originRepository.GetById(id);
            if (clothe == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            Origin Origin = new Origin(name,address);
            originRepository.Update(id, Origin);
        }
        public IEnumerable<Origin> GetList(string? key, int? pageSize, int? page)
        {
            return originRepository.GetList(key, pageSize ?? int.MaxValue, page ?? 1);
        }

        public Origin GetById(int id)
        {
            return originRepository.GetById(id);
        }
    }
}


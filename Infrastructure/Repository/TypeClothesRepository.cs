
using Domain.Cloth;
using Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TypeClothesRepository : ITypeClothesRepository
    {

        public void Add(TypeClothes typeClothes)
        {
            using (var db = new MyDbContext())
            {
                TypeClothes Type = new TypeClothes(typeClothes.Name, typeClothes.Limit);
                db.Add(Type);
                db.SaveChanges();
            }
        }

        public void Delete(TypeClothes typeclothes)
        {
            using (var db = new MyDbContext())
            {
                db.TypeClothes.Remove(typeclothes);
                db.SaveChanges();
            }
        }

        public TypeClothes GetById(int id)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.TypeClothes.Include(e => e.Clothes).SingleOrDefault(e => e.Id == id);
                return rs;
            }
        }

        public IEnumerable<TypeClothes> GetList(string? key, int? pageSize, int? page)
        {
            using (var db = new MyDbContext())
            {
                IQueryable<TypeClothes> rs = db.TypeClothes.Include(e => e.Clothes).OrderBy(e => e.Name);
                if (key != null) rs = rs.Where(e => e.Name.ToUpper().Contains(key.ToUpper()));
                rs = rs.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                return rs.ToList();
            }
        }


        public void Update(int id, TypeClothes typeCLothes)
        {
            using (var db = new MyDbContext())
            {
                TypeClothes ClothesBefore = db.TypeClothes.Where(e => e.Id == id).FirstOrDefault();
                ClothesBefore.Update(typeCLothes.Name, typeCLothes.Limit);
                db.SaveChanges();
            }
        }
    }
}

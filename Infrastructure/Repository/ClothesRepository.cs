using Domain.Cloth;
using Microsoft.EntityFrameworkCore;
using Infrastructure.IRepository;

namespace Infrastructure.Repository
{
    public class ClothesRepository : IClothesRepository
    {
        public void Add(Clothes clothe)
        {
            using (var db = new MyDbContext())
            {
                db.Add(clothe);
                db.SaveChanges();
            }
        }

        public void Delete(Clothes clothe)
        {
            using (var db = new MyDbContext())
            {
                db.Clothes.Remove(clothe);
                db.SaveChanges();
            }
        }

        public Clothes GetById(int id)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Clothes.Include(e => e.TypeClothes).SingleOrDefault(e => e.Id == id);
                return rs;
            }
        }

        public IEnumerable<Clothes> GetList(string? key, int? pageSize, int? page)
        {
            using (var db = new MyDbContext())
            {
                IQueryable<Clothes> rs = db.Clothes.Include(e => e.DetailInvoices).Include(e => e.DetailInvoiceLaundries).OrderBy(e => e.Name);
                if (key != null) rs = rs.Where(e => e.Name.ToUpper().Contains(key.ToUpper()));
                rs = rs.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                return rs.ToList();
            }
        }

        public void Update(int id, Clothes clothe)
        {
            using (var db = new MyDbContext())
            {
                Clothes ClothesBefore = db.Clothes.Include(e => e.TypeClothes).SingleOrDefault(e => e.Id == id);
                Status StatusBefore = ClothesBefore.Status;
                ClothesBefore.Update(clothe.Name, clothe.Description, clothe.Size, clothe.Price, clothe.RentalPrice, clothe.TypeClothesId, clothe.OriginId, clothe.Status);
                if (StatusBefore == Status.Available && clothe.Status == Status.Rental)
                    ClothesBefore.ChangeRentalTime();
                if ((StatusBefore != Status.Available || StatusBefore != Status.Rental) && clothe.Status != Status.Sold)
                    ClothesBefore.ChangeStatus(StatusBefore);
                db.SaveChanges();
            }
        }
    }
}

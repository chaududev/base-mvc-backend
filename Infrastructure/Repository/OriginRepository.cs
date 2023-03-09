using Domain.Cloth;
using Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OriginRepository : IOriginRepository
    {

        public void Add(Origin origin)
        {
            using (var db = new MyDbContext())
            {
                Origin Type = new Origin(origin.Name, origin.Address);
                db.Add(Type);
                db.SaveChanges();
            }
        }

        public void Delete(Origin origin)
        {
            using (var db = new MyDbContext())
            {
                db.Origins.Remove(origin);
                db.SaveChanges();
            }
        }

        public Origin GetById(int id)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Origins.Include(e => e.Clothes).SingleOrDefault(e => e.Id == id);
                return rs;
            }
        }

        public IEnumerable<Origin> GetList(string? key,int? pageSize, int? page)
        {
            using (var db = new MyDbContext())
            {
                IQueryable<Origin> rs = db.Origins.Include(e => e.Clothes).OrderBy(e => e.Name);
                if (key != null) rs = rs.Where(e => e.Name.ToUpper().Contains(key.ToUpper()));
                rs = rs.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                return rs.ToList();
            }
        }


        public void Update(int id, Origin origin)
        {
            using (var db = new MyDbContext())
            {
                Origin ClothesBefore = db.Origins.Where(e => e.Id == id).FirstOrDefault();
                ClothesBefore.Update(origin.Name, origin.Address);
                db.SaveChanges();
            }
        }
    }
}



using Model1.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class MapsDao
    {
        OnlineDbOrder db = null;
        public MapsDao()
        {
            db = new OnlineDbOrder();
        }
        public Maps GetMaps()
        {
            return db.Mapss.SingleOrDefault(x => x.Status == true);
        }
        public List<Maps> ListAll()
        {
            return db.Mapss.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<Maps> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Maps> model = db.Mapss;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Maps ViewDetail(long id)
        {
            return db.Mapss.Find(id);
        }
        public IEnumerable<Maps> ListAll(long searchString, int page, int pageSize)
        {
            IQueryable<Maps> model = db.Mapss;

            model = model.Where(x => x.ID == searchString);

            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public List<Maps> ListByGroupId(long groupId)
        {
            return db.Mapss.Where(x => x.ID == groupId && x.Status == true).OrderBy(x => x.ID).ToList();
        }

        public List<Maps> ListMap(int top)
        {
            return db.Mapss.Where(x => x.Status == true).OrderByDescending(x => x.ID).Take(top).ToList();
        }

        public long Create(Maps map)
        {
            
            db.Mapss.Add(map);
            db.SaveChanges();
            return map.ID;
        }
    }
}

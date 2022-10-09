using BusinessLogicLayer.Models;
using DataAccessLayer.Date;
using DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private RestReservDbContext _db;

        public CategoryRepository(RestReservDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}

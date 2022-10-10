using DataAccessLayer.Date;
using DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RestReservDbContext _db;

        public UnitOfWork(RestReservDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);

        }
        public ICategoryRepository Category { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

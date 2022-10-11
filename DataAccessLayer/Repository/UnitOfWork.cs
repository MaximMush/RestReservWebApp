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
    public class UnitOfWork : IUnitOfWork
    {
        private RestReservDbContext _db;

        public UnitOfWork(RestReservDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Restaurant = new RestaurantRepository(_db);
            User = new UserRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            RestaurantAddress = new RestaurantAddressRepository (_db);

        }
        public ICategoryRepository Category { get; private set; }
        public IRestaurantRepository Restaurant { get; private set; }
        public IUserRepository User { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IRestaurantAddressRepository RestaurantAddress { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

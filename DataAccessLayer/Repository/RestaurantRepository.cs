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
    internal class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private RestReservDbContext _db;

        public RestaurantRepository(RestReservDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Restaurant obj)
        {
            _db.restaurants.Update(obj);
        }
    }
}


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
	public class RestaurantAddressRepository : Repository<RestaurantsAddress>, IRestaurantAddressRepository
    {
        private RestReservDbContext _db;

        public RestaurantAddressRepository(RestReservDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(RestaurantsAddress obj)
        {
            _db.restaurantsAddress.Update(obj);
        }
    }
}

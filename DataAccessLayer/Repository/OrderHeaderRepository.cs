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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private RestReservDbContext _db;

        public OrderHeaderRepository(RestReservDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderHeader obj)
        {
            _db.orderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;

            }
        }

    }
}

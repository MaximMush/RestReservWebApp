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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private RestReservDbContext _db;

        public OrderDetailRepository(RestReservDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderDetail obj)
        {
            _db.orderDetail.Update(obj);
        }
    }
}

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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private RestReservDbContext _db;

        public UserRepository(RestReservDbContext db) : base(db)
        {
            _db = db;
        }

    }
}

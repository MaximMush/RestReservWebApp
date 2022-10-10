using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.IRepository
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        void Update(Restaurant obj);
    }
}

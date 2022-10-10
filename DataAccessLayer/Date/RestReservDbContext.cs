using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Date
{
    public class RestReservDbContext : IdentityDbContext<User>
    {
        public RestReservDbContext(DbContextOptions<RestReservDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; } = null!;
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Restaurant> restaurants { get; set; } = null!;
        public DbSet<OrderHeader> orderHeaders { get; set; } = null!;
        public DbSet<OrderDetail> orderDetail { get; set; } = null!;
        public DbSet<RestaurantsAddress> restaurantsAddress { get; set; } = null!;
    }
}

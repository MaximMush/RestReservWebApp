using BusinessLogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Date
{
    public class RestReservDbContext : DbContext
    {
        public RestReservDbContext(DbContextOptions<RestReservDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
    }
}

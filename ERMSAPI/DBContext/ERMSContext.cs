using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ERMSAPI.Models;
namespace ERMSAPI.DBContext
{
    public class ERMSContext : DbContext
    {
        public DbSet<Users> Users{ get; set; }

        public  ERMSContext(DbContextOptions<ERMSContext> opt ) : base(opt) {
        
        }

          

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsole
{
    public class CustomerDBContext : DbContext
    {

        private readonly string _connectionString;
        public CustomerDBContext() 
        {
            _connectionString = "DB_Connection_String";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

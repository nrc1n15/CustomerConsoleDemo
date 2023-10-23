using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerConsole.Models;

namespace CustomerConsole.DataContexts;

public class CustomerDBContext : DbContext
{
    private readonly string _connectionString;
    public CustomerDBContext() 
    {
        _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CustomersDB";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    public DbSet<Customer> Customers { get; set; }
}

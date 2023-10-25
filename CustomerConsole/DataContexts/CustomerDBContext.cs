using Microsoft.EntityFrameworkCore;
using CustomerConsole.Models;

namespace CustomerConsole.DataContexts;

public class CustomerDBContext : DbContext
{
    public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options) 
    {
    }

    public DbSet<Customer> Customers { get; set; }
}

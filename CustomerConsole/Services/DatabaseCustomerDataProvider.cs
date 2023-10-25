//4(b).- Implement the Interface in DatabaseCustomerDataProvider

using Microsoft.EntityFrameworkCore;
using CustomerConsole.Models;
using CustomerConsole.DataContexts;

namespace CustomerConsole.Services;

public class DatabaseCustomerDataProvider : ICustomerDataProvider
{
    private readonly CustomerDBContext _context;

    public DatabaseCustomerDataProvider(CustomerDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetCustomerList()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomerListByAgeRange(int startAge, int endAge)
    {
        return await _context.Customers.Where(c => c.Age >= startAge && c.Age <= endAge).ToListAsync();
    }

    public async Task<bool> SaveCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<bool> SaveCustomerList(List<Customer> customerList)
    {
        _context.Customers.AddRange(customerList);
        return (await _context.SaveChangesAsync() >= 0);
    }

}

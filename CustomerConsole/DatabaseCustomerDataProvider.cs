//4(b).- Implement the Interface in DatabaseCustomerDataProvider

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsole;

public class DatabaseCustomerDataProvider : ICustomerDataProvider
{
    private readonly CustomerDBContext _context;

    public DatabaseCustomerDataProvider(CustomerDBContext context)
    {
        _context = context;
    }
    public List<Customer> GetCusomterList()
    {
        return _context.Customers.ToList();
    }

    public List<Customer> GetCustomerListByAgeRange(int startAge, int endAge)
    {
        return _context.Customers.Where(c => c.Age >= startAge && c.Age <= endAge).ToList();
    }

    public int SaveCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        return _context.SaveChanges();
    }

    public int SaveCustomerList(List<Customer> customerList)
    {
        _context.Customers.AddRange(customerList);
        return _context.SaveChanges();
    }

}

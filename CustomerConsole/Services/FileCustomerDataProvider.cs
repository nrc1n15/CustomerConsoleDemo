//4.- Implement the Interface in FileCustomerDataProvider

using CustomerConsole.DataContexts;
using CustomerConsole.Models;

namespace CustomerConsole.Services;

public class FileCustomerDataProvider : ICustomerDataProvider
{
    private CustomerFileContext _fileContext;
    public FileCustomerDataProvider(CustomerFileContext fileContext) 
    {
        _fileContext = fileContext;
    }

    public async Task<IEnumerable<Customer>> GetCustomerList()
    {
        return await _fileContext.RetrieveCustomersAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomerListByAgeRange(int startAge, int endAge)
    {
        return await _fileContext.RetrieveCustomersAsync();
    }

    public async Task<bool> SaveCustomer(Customer customer)
    {
        return await _fileContext.SaveCustomerAsync(customer);
    }

    public async Task<bool> SaveCustomerList(List<Customer> customerList)
    {
        return await _fileContext.SaveCustomerListAsync(customerList);
    }
}

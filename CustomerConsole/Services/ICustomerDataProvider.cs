//3.- Create an Interface for CustomerDataProvider to be used to 
//	GetCustomerList,
//    GetCustomerListByAgeRange,
//    SaveCutomer,
//    SaveCustomerList

using CustomerConsole.Models;

namespace CustomerConsole.Services;

public interface ICustomerDataProvider
{
    Task<IEnumerable<Customer>> GetCustomerList();

    Task<IEnumerable<Customer>> GetCustomerListByAgeRange(int startAge, int endAge);

    Task<bool> SaveCustomer(Customer customer);

    Task<bool> SaveCustomerList(List<Customer> customerList);
}

//3.- Create an Interface for CustomerDataProvider to be used to 
//	GetCustomerList,
//    GetCustomerListByAgeRange,
//    SaveCutomer,
//    SaveCustomerList

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsole;

public interface ICustomerDataProvider
{
    List<Customer> GetCusomterList();   

    List<Customer> GetCustomerListByAgeRange(int startAge, int endAge);

    int SaveCustomer(Customer customer);

    int SaveCustomerList(List<Customer> customerList);
}

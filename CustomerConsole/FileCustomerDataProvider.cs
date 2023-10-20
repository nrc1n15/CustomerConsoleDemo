//4.- Implement the Interface in FileCustomerDataProvider

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsole;

public class FileCustomerDataProvider : ICustomerDataProvider
{

    private string _path;
    private const string newLine = "\r\n";
    public FileCustomerDataProvider(string path) 
    {
        _path = path;
        createFileIfNotExists(_path);
    }

    private void createFileIfNotExists(string path)
    {

        if (!File.Exists(path))
        {
            File.WriteAllText(path,null);
        }

    }

    public List<Customer> GetCusomterList()
    {
        string[] lines = File.ReadAllLines(_path);
        var customerList = new List<Customer>();
        foreach (string line in lines)
        {
            var customer = line.Split(',');
            customerList.Add(new Customer() 
            { 
                Id = Int32.Parse(customer[0]), 
                Name = customer[1], 
                Age = Int32.Parse(customer[2]), 
                Email = customer[3]
            });
        }
        return customerList;
    }

    public List<Customer> GetCustomerListByAgeRange(int startAge, int endAge)
    {
        string[] lines = File.ReadAllLines(_path);
        var customerList = new List<Customer>();
        foreach (string line in lines)
        {
            var customer = line.Split(',');
            if (Int32.Parse(customer[2]) >= startAge && Int32.Parse(customer[2]) <= endAge)
            {
                customerList.Add(new Customer()
                {
                    Id = Int32.Parse(customer[0]),
                    Name = customer[1],
                    Age = Int32.Parse(customer[2]),
                    Email = customer[3]
                });
            }
        }
        return customerList;

    }

    public int SaveCustomer(Customer customer)
    {
        string line = $"{customer.Id},{customer.Name},{customer.Age},{customer.Email}";
        File.AppendAllText(_path, line);
        File.AppendAllText(_path, newLine);
        return 1;
    }

    public int SaveCustomerList(List<Customer> customerList)
    {
        foreach (var customer in customerList) 
        {
            string line = $"{customer.Id},{customer.Name},{customer.Age},{customer.Email}";
            File.AppendAllText(_path, line);
            File.AppendAllText(_path, newLine);
        }
        return 1;
    }
}

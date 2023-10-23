//4.- Implement the Interface in FileCustomerDataProvider

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerConsole.Models;

namespace CustomerConsole.Services;

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

    public async Task<IEnumerable<Customer>> GetCustomerList()
    {
        string[] lines = await File.ReadAllLinesAsync(_path);
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

    public async Task<IEnumerable<Customer>> GetCustomerListByAgeRange(int startAge, int endAge)
    {
        string[] lines = await File.ReadAllLinesAsync(_path);
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

    public async Task<bool> SaveCustomer(Customer customer)
    {
        string[] lines = await File.ReadAllLinesAsync(_path);
        customer.Id = lines.Count() + 1;
        string line = $"{customer.Id},{customer.Name},{customer.Age},{customer.Email}";
        await File.AppendAllTextAsync(_path, line);
        await File.AppendAllTextAsync(_path, newLine);
        return true;
    }

    public async Task<bool> SaveCustomerList(List<Customer> customerList)
    {
        string[] lines = await File.ReadAllLinesAsync(_path);
        int counter = lines.Count() + 1;
        foreach (var customer in customerList)
        {
            customer.Id = counter++;
            string line = $"{customer.Id},{customer.Name},{customer.Age},{customer.Email}";
            await File.AppendAllTextAsync(_path, line);
            await File.AppendAllTextAsync(_path, newLine);
        }
        return true;
    }
}

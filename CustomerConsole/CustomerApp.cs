using CustomerConsole.DataContexts;
using CustomerConsole.Models;
using CustomerConsole.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CustomerConsole;

public class CustomerApp
{
    private readonly ICustomerDataProvider _customers;
    private readonly CustomerDataStore _customerData;
    private const int maxAge = 100; 
    public CustomerApp(ICustomerDataProvider customers, CustomerDataStore customerData)
    {
        _customers = customers;
        _customerData = customerData;
    }
    public async Task<bool> Execute(CancellationToken stoppingToken = default)
    {

        //5.- Populate the list with at least three customers populating all values for each object
        await _customers.SaveCustomerList(_customerData.InitialCustomers);

        //6.- Implement a query using LINQ to retrieve customers older than 30 years. Store the query result
        // in a variable.
        var customersOlderThan30 = await _customers.GetCustomerListByAgeRange(31, maxAge);

        //7.- Display the names, ages, and email addresses of the customers obtained from the LINQ query.
        Console.WriteLine("=========== Customers Older than 30 =============");
        printInformation(customersOlderThan30.ToList());

        //8.- Implement a method using lambda functions to retrieve customers whose names contain the
        // string "Doe". Store the query result in a variable.
        var listOfCustomers = await _customers.GetCustomerList();
        var customersWithDoe = (List<Customer> customers) => customers.
                    Where(c => c.Name.Contains("Doe")).ToList();
        var customersDoe = customersWithDoe(listOfCustomers.ToList());

        //9.- Display the names, ages, and email addresses of the customers obtained from the lambda query.
        Console.WriteLine("=========== Customers With Doe =============");
        printInformation(customersDoe);

        //10.- Implement code to serialize the list of customers to JSON using the System.Text.Json namespace.
        string jsonString = JsonSerializer.Serialize(listOfCustomers,
            new JsonSerializerOptions { WriteIndented = true });

        //11.- Display the serialized JSON on the console.
        Console.WriteLine("=========== Serialized representation of customers =============");
        Console.WriteLine(jsonString);

        //12.- Implement code to deserialize the JSON back into a list of Customer objects. Display the names,
        // ages, and email addresses of the deserialized customers on the console.
        var deserialized = JsonSerializer.Deserialize<List<Customer>>(jsonString);
        Console.WriteLine("=========== Deserialized representation of customers =============");
        printInformation(deserialized);

        return true;
    }

    // Method to print information
    private void printInformation(List<Customer> customerList)
    {
        foreach (var customer in customerList)
        {
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"    Age: {customer.Age}");
            Console.WriteLine($"    Email: {customer.Email}");
            Console.WriteLine("");
        }
    }
}
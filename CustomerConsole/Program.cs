using CustomerConsole.DataContexts;
using CustomerConsole.Models;
using CustomerConsole.Services;
using System.Text.Json;

string directory = Directory.GetParent(Directory.GetCurrentDirectory()).
    Parent.Parent.FullName;
string file = "DBCustomers.txt";
string path = $"{directory}\\{file}";
var context = new CustomerDBContext();

// Using a file data provider
var customerDataProvider = new FileCustomerDataProvider(path);
// Using a database data provider
//var customerDataProvider = new DatabaseCustomerDataProvider(context);

//5.- Populate the list with at least three customers populating all values for each object

var customerList = new CustomerDataStore().InitialCustomers;
await customerDataProvider.SaveCustomerList(customerList);

//6.- Implement a query using LINQ to retrieve customers older than 30 years. Store the query result
// in a variable.

var customers = await customerDataProvider.GetCustomerList();
var customersOlderThan30 = customers.Where(c => c.Age > 30).ToList();

//7.- Display the names, ages, and email addresses of the customers obtained from the LINQ query.

Console.WriteLine("=========== Customers Older than 30 =============");
printInformation(customersOlderThan30);

//8.- Implement a method using lambda functions to retrieve customers whose names contain the
// string "Doe". Store the query result in a variable.

var customersWithDoe = (List<Customer> customers) => customers.
            Where(c => c.Name.Contains("Doe")).ToList();
var customersDoe = customersWithDoe(customers.ToList());

//9.- Display the names, ages, and email addresses of the customers obtained from the lambda query.

Console.WriteLine("=========== Customers With Doe =============");
printInformation(customersDoe);

//10.- Implement code to serialize the list of customers to JSON using the System.Text.Json namespace.

string jsonString = JsonSerializer.Serialize(customers,
    new JsonSerializerOptions { WriteIndented = true });

//11.- Display the serialized JSON on the console.

Console.WriteLine("=========== Serialized representation of customers =============");
Console.WriteLine(jsonString);

//12.- Implement code to deserialize the JSON back into a list of Customer objects. Display the names,
// ages, and email addresses of the deserialized customers on the console.
var deserialized = JsonSerializer.Deserialize<List<Customer>>(jsonString);

Console.WriteLine("=========== Deserialized representation of customers =============");
printInformation(deserialized);

// Method to print information
void printInformation(List<Customer> customerList)
{
    foreach (var customer in customerList)
    {
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"    Age: {customer.Age}");
        Console.WriteLine($"    Email: {customer.Email}");
        Console.WriteLine("");
    }
}
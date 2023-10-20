using CustomerConsole;
using Microsoft.EntityFrameworkCore;
using System.IO.Enumeration;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

string directory = Directory.GetParent(Directory.GetCurrentDirectory()).
    Parent.Parent.FullName;
string file = "DBCustomers.txt";
string path = $"{directory}\\{file}";
var context = new CustomerDBContext();


// Using a file data provider
//var customerDataProvider = new FileCustomerDataProvider(path);
// Using a database data provider
var customerDataProvider = new DatabaseCustomerDataProvider(context);


//5.- Populate the list with at least three customers populating all values for each object

var customerList = new List<Customer>() {
        new Customer()
        {
            Id = 1, 
            Name = "Noe Rodriguez", 
            Age = 33, 
            Email = "noe.rodriguez@email.com"
        },
        new Customer()
        {
            Id = 2, 
            Name = "Juan Perez", 
            Age = 25, 
            Email = "juan.perez@email.com"
        },
        new Customer()
        {
            Id = 3, 
            Name = "Pedro Aguirre", 
            Age = 38, 
            Email = "pedro.aguirre@email.com"
        },
        new Customer()
        {
            Id = 4, 
            Name = "John Doe", 
            Age = 29, 
            Email = "john.doe@email.com"
        },
        new Customer()
        {
            Id = 5, 
            Name = "Martin Guevara", 
            Age = 50, 
            Email = "martin.guevara@email.com"
        },
        new Customer()
        {
            Id = 6, 
            Name = "Norma Morales", 
            Age = 31, 
            Email = "norma.morales@email.com"
        },
        new Customer()
        {
            Id = 7, 
            Name = "Maria Doe", 
            Age = 37, 
            Email = "maria.doe@email.com"
        },
        new Customer()
        {
            Id = 8, 
            Name = "Guadalupe Lopez", 
            Age = 23, 
            Email = "guadalupe.lopez@email.com"
        },
};

customerDataProvider.SaveCustomerList(customerList);



//6.- Implement a query using LINQ to retrieve customers older than 30 years. Store the query result
// in a variable.
var customers = customerDataProvider.GetCusomterList();


//7.- Display the names, ages, and email addresses of the customers obtained from the LINQ query.

var customersOlderThan30 = customerDataProvider.GetCusomterList().
    Where(c => c.Age > 30).ToList();

Console.WriteLine("=========== Customers Older than 30 =============");
foreach (var customer in customersOlderThan30)
{
    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"    Age: {customer.Age}");
    Console.WriteLine($"    Email: {customer.Email}");
    Console.WriteLine("");
}


//8.- Implement a method using lambda functions to retrieve customers whose names contain the
// string "Doe". Store the query result in a variable.

var customersWithDoe = (List<Customer> customers) => customers.
            Where(c => c.Name.Contains("Doe")).ToList();

var customersDoe = customersWithDoe(customers);

//9.- Display the names, ages, and email addresses of the customers obtained from the lambda query.

Console.WriteLine("=========== Customers With Doe =============");
foreach (var customer in customersDoe)
{
    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"    Age: {customer.Age}");
    Console.WriteLine($"    Email: {customer.Email}");
    Console.WriteLine("");
}


//10.- Implement code to serialize the list of customers to JSON using the System.Text.Json namespace.

string jsonString = JsonSerializer.Serialize(customers, 
    new JsonSerializerOptions { WriteIndented = true});

//11.- Display the serialized JSON on the console.

Console.WriteLine("=========== Serialized representation of customers =============");
Console.WriteLine(jsonString);

//12.- Implement code to deserialize the JSON back into a list of Customer objects. Display the names,
// ages, and email addresses of the deserialized customers on the console.
var deserialized = JsonSerializer.Deserialize<List<Customer>>(jsonString);

Console.WriteLine("=========== Deserialized representation of customers =============");
foreach (var customer in deserialized)
{
    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"    Age: {customer.Age}");
    Console.WriteLine($"    Email: {customer.Email}");
    Console.WriteLine("");
}
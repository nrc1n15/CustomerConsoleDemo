using CustomerConsole.Models;

namespace CustomerConsole.DataContexts;

public class CustomerDataStore
{
    public List<Customer> InitialCustomers { get; set; }

    public CustomerDataStore()
    {
        InitialCustomers = new List<Customer>() 
        {
            new Customer()
            {
                Name = "Noe Rodriguez",
                Age = 19,
                Email = "noe.rodriguez@email.com"
            },
            new Customer()
            {
                Name = "Juan Perez",
                Age = 25,
                Email = "juan.perez@email.com"
            },
            new Customer()
            {
                Name = "Pedro Aguirre",
                Age = 38,
                Email = "pedro.aguirre@email.com"
            },
            new Customer()
            {
                Name = "John Doe",
                Age = 29,
                Email = "john.doe@email.com"
            },
            new Customer()
            {
                Name = "Martin Guevara",
                Age = 50,
                Email = "martin.guevara@email.com"
            },
            new Customer()
            {
                Name = "Norma Morales",
                Age = 31,
                Email = "norma.morales@email.com"
            },
            new Customer()
            {
                Name = "Maria Doe",
                Age = 37,
                Email = "maria.doe@email.com"
            },
            new Customer()
            {
                Name = "Guadalupe Lopez",
                Age = 23,
                Email = "guadalupe.lopez@email.com"
            },
        };
    }
}

using CustomerConsole;
using CustomerConsole.DataContexts;
using CustomerConsole.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var app = Host.CreateDefaultBuilder()
    .UseContentRoot(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
    .ConfigureLogging(config => config.ClearProviders())
    .ConfigureHostConfiguration(hostConfig =>
    {
        hostConfig.AddJsonFile("appsettings.json",optional: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<ICustomerDataProvider, DatabaseCustomerDataProvider>();
        //services.AddSingleton<ICustomerDataProvider, FileCustomerDataProvider>();
        services.AddDbContext<CustomerDBContext>(dbContextOptions =>
            dbContextOptions.UseSqlServer(hostContext.Configuration.GetSection("ConnectionStrings:CustomerDB").Value));
        services.AddSingleton<CustomerDataStore>();
        services.AddSingleton<CustomerFileContext>();
        services.AddSingleton<CustomerApp>();

    })
    .Build().Services.GetRequiredService<CustomerApp>(); 

await app.Execute();

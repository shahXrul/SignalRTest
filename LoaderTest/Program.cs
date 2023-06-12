// See https://aka.ms/new-console-template for more information
using LoaderTest;
using LoaderTest.DataAccess;
using LoaderTest.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Initializing");
var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddTransient<SqlHelper>();
        services.AddSingleton<TemplateService>();
    }).Build();

var service = host.Services.GetRequiredService<TemplateService>();
service.Run();

//var tasks = new List<Task>();

//while (true)
//{
//    Console.WriteLine("G");
//    string input = Console.ReadLine();
//    Console.WriteLine("\nYou pressed the '{0}' key.", input);

//    if (input == "q")
//    {
//        return 1;
//    }
//    else if (input == "a")
//    {
//        tasks.Add(
//       Task.Run(() =>
//            {
//                QueryRunner runner = new QueryRunner();
//                Task.Delay(1000).Wait();
//                runner.RunMeInsert();
//            })
//        );
//    }
//    else if (input == "s")
//    {
//        for (int i = tasks.Count - 1; i >= 0; i--)
//        {
//            if (tasks[i].Status == TaskStatus.RanToCompletion)
//            {
//                Console.WriteLine("Task {0} complete.", i);
//                tasks.RemoveAt(i);
//            }
//        }
//    }
//    else
//            {
//        tasks.Add(
//           Task.Run(() =>
//            {
//                QueryRunner runner = new QueryRunner();
//                Task.Delay(1200).Wait();
//                runner.RunMe();
//            })
//        );
//    }
//}
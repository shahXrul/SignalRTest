using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ConsoleAppClient
{
    //var connection = new HubConnectionBuilder()
    //            .WithUrl("https://localhost:44371/signalr")
    //            .Build();
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnection("https://localhost:44371/signalr");
            var hubProxy = connection.CreateHubProxy("chathub");

            hubProxy.On<string, string>("addNewMessageToPage", (user, message) =>
            {
                Console.WriteLine($"{user}: {message}");
            });

            connection.Start().Wait();

            Console.WriteLine("Connected to the server. Enter your name:");
            var user = Console.ReadLine();

            Console.WriteLine("Enter a message (or 'exit' to quit):");
            while (true)
            {
                var message = Console.ReadLine();

                if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                hubProxy.Invoke("Send", user, message).Wait();
            }

            connection.Stop();
        }
    }
}

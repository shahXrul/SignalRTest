using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
            var currentProcess = Process.GetCurrentProcess();
            int processId = currentProcess.Id;
            string processName = currentProcess.ProcessName;

            Console.WriteLine($"Process ID: {processId}");
            Console.WriteLine($"Process Name: {processName}");

            string username = Environment.UserName;

            var aa = CredentialCache.DefaultNetworkCredentials;


            var connection = new HubConnection("https://localhost/Quest.API/signalr");
            connection.Credentials = new NetworkCredential("AMR\\sys_quest", "passowrd!");
            var hubProxy = connection.CreateHubProxy("QuestSignalHub");

            hubProxy.On<string, string>("addNewMessageToPage", (user, message) =>
            {
                Console.WriteLine($"userme:::{user}: {message}");
            });

            hubProxy.On<string>("testMessage", (msg) =>
            {
                Console.WriteLine(msg);
            });

            hubProxy.On<string>("ReceiveCeidTemplate", (msg) =>
            {
                Console.WriteLine(msg);
            });

            hubProxy.On<string>("ReceiveMessage", (msg) =>
            {
                Console.WriteLine(msg);

            });
            hubProxy.On<List<KeyValuePair<string, string>>>("getConnectedUser", connectedUsers =>
            {
                // Map the connected users to a list of strings
                var connectedUsersList = connectedUsers.Select(user => $"Connection ID: {user.Key}, User Identity: {user.Value}").ToList();

                Console.WriteLine("Total connected user: "+ connectedUsers.Count);
                // Display the connected users in the console
                Console.WriteLine(string.Join(Environment.NewLine, connectedUsersList));
            });
            
            connection.Start().Wait();


            Console.WriteLine("Enter a message (or 'exit' to quit):");
            while (true)
            {
                var message = Console.ReadLine();

                if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                myclass m = new myclass()
                {
                    name = "A",
                    message = "B"
                };

                //var myObject = new MyObject("value1", "value2");

                //hubProxy.Invoke("JobStatusSignal", myObject).Wait();

                if(message == "getuser")
                {
                    hubProxy.Invoke(method: "GetConnectedUser").Wait();
                }
                else if (message.Contains("join"))
                {
                    var facility = message.Replace("join", "").Trim();
                    hubProxy.Invoke(method: "JoinGroupByFacility", facility).Wait();
                }
                else if (message.ToLower().Contains("ceid"))
                {
                    //ceid f24 cidname
                    var msg = message.Split(' ');
                    var facility = msg[1];
                    var ceid = msg[2];
                    //hubProxy.Invoke(method: "UpdateCeidTemplate", facility, DateTime.Now.ToString()+"CEID").Wait();
                    hubProxy.Invoke(method: "UpdateCeidTemplate", facility, ceid).Wait();

                }
                else if (message == "test")
                {
                    hubProxy.Invoke(method: "TestMessage", message).Wait();

                }
            }
            
            connection.Stop();
        }

        public record MyObject(string name,string message);

        public class myclass
        {
            public string name { get; set; }
            public string message { get; set; }
        }

        public class ConnectedUsers
        {
            public string ConnectionId { get; set; }
            public string UserId { get; set; }
        }
    }
}

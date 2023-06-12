using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace frameworkapi
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            var msg = new mesage()
            {
                name = name,
                message = message
            };
            Clients.All.addNewMessageToPage(msg);
        }

        class mesage
        {
            public string name { get; set; }
            public string message { get; set; }
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientSide
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var connection = new HubConnectionBuilder()
          .WithUrl("https://localhost:7054/chathub")
          .Build();

      connection.On<string, string>("ReceiveMessage", (user, message) =>
      {
        Console.WriteLine($"{user}: {message}");
      });

      try
      {
        await connection.StartAsync();
        Console.WriteLine("Connection started");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Connection error: {ex.Message}");
      }

      while (true)
      {
        var message = Console.ReadLine();
        if (message == null) continue;
        await connection.InvokeAsync("SendMessage", "Client", message);
      }
    }
  }
}

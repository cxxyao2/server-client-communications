using System;
using WebSocketSharp;

namespace ClientSide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://localhost:8080/echoall"))
            {
                ws.OnMessage += (sender, e) =>
                    Console.WriteLine($"Received from server: {e.Data}");

                ws.Connect();
                Console.WriteLine("WebSocket client connected");

                // Send a test message
                ws.Send("Hello, WebSocket Server!");

                Console.ReadKey(true);
            }
        }
    }
}

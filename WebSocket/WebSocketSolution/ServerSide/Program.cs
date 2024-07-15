using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServerSide
{
    public class WebSocketServerExample: WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Received message from client: {e.Data}");

            // Echo the message back
            Send("Server got your message: " + e.Data);
        }
    }

    public class EchoAll : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Received message from EchoALl client: {e.Data}");

            // Echo the message back
            Sessions.Broadcast("Server broadcasts your message: " + e.Data);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new WebSocketServer("ws://localhost:8080");
            server.AddWebSocketService<WebSocketServerExample>("/echo");
            server.AddWebSocketService<EchoAll>("/echoall");
            server.Start();

            Console.WriteLine("WebSocket server started at ws://localhost:8080/echo");
            Console.WriteLine("WebSocket server started at ws://localhost:8080/echoall");
            Console.ReadKey(true);

            server.Stop();
        }
    }
}


using Grpc.Net.Client;
using System;

namespace GrpcClient
{


internal class Program
{
     static async Task Main(string[] args)
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        using var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
        Console.WriteLine($"Greetings: {reply.Message}");
          var added = await client.AddAsync(new AddRequest { Number1 = 1, Number2 = 4 });
            Console.WriteLine($"The result of Addition is :{added.Sum}");
        Console.WriteLine("press any key to exit");


    }
}
}
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = new HelloRequest { Name = "Mithun " };
            var input2 = new TestSvc { Id = "Sahithi" };

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            

            var reply = await client.SayHelloAsync(input);
            var reply2 = await client.SayHello2Async(input2);

            Console.WriteLine(reply.Message);
            Console.WriteLine(reply2.Message);
            Console.ReadLine();

        }
    }
}

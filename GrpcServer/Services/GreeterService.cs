using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcServer
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<HelloReply> SayHello2(TestSvc request, ServerCallContext context)
        {
            //return base.snap(request, context);
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Id + " - from sayhello2 service"
            });
        }

        public override Task<HelloReply> service1(Customer obj, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Service1 - Hello  " + obj.FirstName
            });
        }

    }
}

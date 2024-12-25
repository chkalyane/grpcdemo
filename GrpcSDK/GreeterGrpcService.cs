using Grpc.Core;
using GrpcNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcSDK
{
    public class GreeterGrpcService : IGreeterGrpcService
    {
        private readonly Greeter.GreeterClient grpcClient;

        public GreeterGrpcService(Greeter.GreeterClient grpcClient)
        {
            this.grpcClient = grpcClient;
        }

        public  Task<string> SayHelloAsync(string name, CancellationToken cancellationToken)
        {
            try
            {
                var result = grpcClient.SayHello(new HelloRequest { Name = name }, cancellationToken: cancellationToken);

                return null;
            }
            catch (RpcException ex)
            {
                throw;
            }

        }
    }
}

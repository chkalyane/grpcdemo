using GrpcNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcSDK
{
    public static class ServiceCollectionExtension
    {
        public static void AddGrpcSdk(this IServiceCollection services)
        {
            services.AddGrpcClient<Greeter.GreeterClient>(client =>
            {
                client.Address = new Uri("https://localhost:7265");
            });

            services.AddScoped<IGreeterGrpcService, GreeterGrpcService>();
        }
    }
}

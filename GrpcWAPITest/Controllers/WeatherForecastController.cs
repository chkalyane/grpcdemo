using Grpc.Core;
using Grpc.Net.Client;
using GrpcNetCore;
using Microsoft.AspNetCore.Mvc;

namespace GrpcWAPITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var target = "http://localhost:7299";
                var channel = GrpcChannel.ForAddress(target);
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(new HelloRequest() { Name = "testing" });
                return Ok(reply);
            }
            catch(RpcException ex)
            {
                var exsdf = ex;
            }
            return Ok("success");

        }
    }
}

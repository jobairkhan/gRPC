using Microsoft.AspNetCore.Mvc;
using System.Threading;
using JK.gRPC.Server;

namespace JK.gRPC.Client.Controllers
{
[ApiController]
[Route("[controller]")]
public class GreetController : ControllerBase
{
    private readonly Greeter.GreeterClient _client;

    public GreetController(Greeter.GreeterClient client)
    {
        _client = client;
    }

    [HttpGet("{name}")]
    public IActionResult Get([FromRoute]string name, CancellationToken cancellation)
    {
        var request = new HelloRequest
        {
            Name = name
        };
        var call = _client.SayHello(request, cancellationToken: cancellation);

        return Ok(call.Message);
    }
}
}

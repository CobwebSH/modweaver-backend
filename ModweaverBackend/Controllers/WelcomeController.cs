using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ModweaverBackend.Controllers;

[ApiController]
[Route("/")]
public class WelcomeController : ControllerBase
{
    private readonly ILogger<WelcomeController> _logger;

    public WelcomeController(ILogger<WelcomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "welcome")]
    public IDictionary<String, String> Get()
    {
        IDictionary<string, string> thing = new Dictionary<string, string>();
        thing.Add("message", "Welcome traveller!");
        thing.Add("documentation", "https://github.com/cobwebsh/modweaver-backend/wiki");
        return thing;
    }
}
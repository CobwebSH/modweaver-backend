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
    public String Get()
    {
        return "{\"message\": \"Welcome traveller!\", \"docs\": \"https://github.com/cobwebsh/modweaver-backend/wiki\"}";
    }
}
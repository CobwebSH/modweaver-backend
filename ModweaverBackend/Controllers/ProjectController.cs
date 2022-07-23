using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ModweaverBackend.Controllers;

[ApiController]
[Route("project/{project}")]
public class ProjectController : ControllerBase
{
    private readonly ILogger<ProjectController> _logger;

    public ProjectController(ILogger<ProjectController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "project")]
    public ContentResult Get(string project)
    {
        var files = Directory.GetFiles("mods");
        var response = new[] { "" };
        string r = "";

        //string response = "\"Error\": \"Not Found\"";
        foreach (var file in files)
        {
            
            var str = file.Split("mods/")[1].Split(".json")[0];
            response = response.Append(str).ToArray();
            if (response.Contains(project))
            {
                r = System.IO.File.ReadAllText("mods/" + project + ".json");
            }
            else
            {
                r = "{\"error\": \"Not found\", \"code\": 404}";
            }
        }
        return Content(r, "application/json");
    }
}
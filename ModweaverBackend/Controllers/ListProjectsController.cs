using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ModweaverBackend.Controllers;

[ApiController]
[Route("projects")]
public class ListProjectsController : ControllerBase
{
    private readonly ILogger<ListProjectsController> _logger;

    public ListProjectsController(ILogger<ListProjectsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Projects")]
    public List<String> Get()
    {
        var files = Directory.GetFiles("mods");
        var response = new[] { "" };
        
        //string response = "\"Error\": \"Not Found\"";
        foreach (var file in files)
        {
            var str = file.Split("mods/")[1].Split(".json")[0];
            response = response.Append(str).ToArray();
        }

        //response = "";
        var r = response.ToList();
        r.Remove("");
        HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
        responseMessage.Headers.Add("Access-Control-Allow-Origin", "*");
        responseMessage.Headers.Add("Content-Type", "application/json");
        return r;
    }
}
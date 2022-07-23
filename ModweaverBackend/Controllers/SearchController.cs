using Microsoft.AspNetCore.Mvc;

namespace ModweaverBackend.Controllers;

[ApiController]
[Route("search/{query}")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;

    public SearchController(ILogger<SearchController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "search")]
    public List<String> Get(string query)
    {
        var files = Directory.GetFiles("mods");
        var response = new[] { "" };
        var resp = new[] { "" };
        bool error = false;

        //string response = "\"Error\": \"Not Found\"";
        foreach (var file in files)
        {
            
            var str = file.Split("mods/")[1].Split(".json")[0];
            response = response.Append(str).ToArray();
        }

        foreach (var thh in response)
        {
            if (thh == query)
            {
                resp[0] = thh;
            } else if (thh.Contains(query))
            {
                resp = resp.Append(thh).ToArray();
            }
        }

        if (resp.Length == 1)
        {
            error = true;
        }
        var respo = resp.ToList();
        respo.Remove("");
        if (error)
        {
            var list = new List<String>();
            list.Add("Error: no results");
            list.Add("404");
            return list;
        }
        return respo;
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class StressController : ControllerBase
{

    private readonly ILogger<StressController> _logger;

    public StressController(ILogger<StressController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public void Get()
    {
        for (int i = 0; i < Environment.ProcessorCount ; i++)
            {
                new Thread(BusyDelay).Start();                
            }   
    }

    [HttpGet("health")]    
    public ActionResult HealthCheck()
    {
        return Ok("Healthy");
    }
     public void BusyDelay()
     {
            long i = 70000000000;
            while (i-- > 0);
     }
}

//az webapp up --resource-group grp-teste --plan ASP-grpteste-9873 --name webapptestelucas --runtime DOTNETCORE:6.0 --os-type linux


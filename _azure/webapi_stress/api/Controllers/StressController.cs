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
     public void BusyDelay()
     {
            long i = 70000000000;
            while (i-- > 0);
     }
}
//az webapp up --runtime dotnet:6 --sku B1 --logs --name fiapscaleout
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers;

[ApiController]
[Route("[app/v1]")]
public class AppNutricaoController : ControllerBase
{
    private readonly ILogger<AppNutricaoController> _logger;

    public AppNutricaoController(ILogger<AppNutricaoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("obter-ingredientes")]
    public void Get()
    {
        
    }
}

using BACKEND.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers;

[ApiController]
[Route("nutri/v1")]
public class AppNutricaoController : ControllerBase
{
    private readonly ILogger<AppNutricaoController> _logger;

    private readonly INutricaoService _nutriService;

    public AppNutricaoController(ILogger<AppNutricaoController> logger, INutricaoService nutricaoService)
    {
        _logger = logger;
        _nutriService = nutricaoService;
    }

    [HttpGet("verificar-consumo")]
    public async Task<IActionResult> VerificarConsumo([FromQuery] int CodProd, int CodUsuario)
    {
        return Ok(await _nutriService.VerificarCosumoDeProdutoPorCodUsuario(CodUsuario, CodProd));
    }
}

using BACKEND.DTO;
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
    public async Task<IActionResult> VerificarConsumo([FromQuery] string CodBarra, int CodUsuario)
    {
        return Ok(new List<Produto>{
                    new Produto {
                        CodBarras = "123",
                        Descricao = "Bolacha",
                        IdProduto = "147852",
                        Marca = "Club Social",
                        Titulo = "Biscoito de sal",
                        UrlImagem = @"http://127.0.0.1:8887/produtoAmendoimBrasil.png",
                        Ingredientes = new List<string>{"Farinha de trigo"}
                    }
                });
        // return Ok(await _nutriService.VerificarCosumoDeProdutoPorCodUsuario(CodUsuario, CodBarra));
    }
}

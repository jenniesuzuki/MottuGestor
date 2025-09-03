using Microsoft.AspNetCore.Mvc;
using MottuGestor.Application.DTOs.Request;
using MottuGestor.Application.UseCases;

namespace MottuGestor.API.Controllers;

[ApiController]
[Route("api/motos")]
public class MotosController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Criar(
        [FromBody] MotoRequest request,
        [FromServices] MotoUseCase useCase,
        CancellationToken ct)
    {
        var resp = await useCase.HandleAsync(request, ct);
        return CreatedAtAction(nameof(ObterPorId), new { id = resp.MotoId }, resp);
    }

    [HttpGet("{id:guid}")]
    public IActionResult ObterPorId(Guid id)
    {
        // Você pode criar um GetMotoUseCase similar
        return Ok(new { message = "TODO" });
    }
}
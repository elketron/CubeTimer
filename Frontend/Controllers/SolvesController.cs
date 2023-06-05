using Microsoft.AspNetCore.Mvc;
using CubeTimerServices.Services;
using CubeTimerData.Models;

[Route("/api/solves")]
[ApiController]
public class SolvesController : ControllerBase
{
    private readonly SolvesService _solvesService;

    public SolvesController(SolvesService solves)
    {
        _solvesService = solves;
    }

    [HttpGet]
    public async Task<ActionResult> GetSolves()
    {
        return Ok(await _solvesService.GetSolves());
    }

    [HttpGet("{Type}")]
    public async Task<ActionResult> GetSolvesOfType(CubeTypes Type)
    {
        return Ok(await _solvesService.GetSolvesOfType(Type));
    }

    [HttpPost]
    public async Task<ActionResult> AddSolve(Solves solve)
    {
        await _solvesService.AddSolve(solve);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveSolve(int id)
    {
        if (await _solvesService.RemoveSolve(id))
        {
            return Ok();
        }

        return NotFound(id);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateSolve(Solves solve)
    {
        if (await _solvesService.UpdateSolve(solve))
        {
            return Ok(solve);
        }

        return NotFound(solve);
    }
}

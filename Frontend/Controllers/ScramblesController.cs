using CubeTimerData.Models;
using CubeTimerServices.Services;
using Microsoft.AspNetCore.Mvc;

[Route("/api/scrambles")]
[ApiController]
public class ScramblesController : ControllerBase
{
    private readonly ScramblerService _scramblerService;

    public ScramblesController(ScramblerService scrambler)
    {
        _scramblerService = scrambler;
    }

    [HttpGet("{t}")]
    public ActionResult GetNewScramble(CubeTypes t)
    {
        return Ok(_scramblerService.GetScramble(t));
    }

    [HttpGet("{t}/{amount}")]
    public ActionResult GetScrambles(CubeTypes t, int amount)
    {
        return Ok(_scramblerService.GetScrambleAmount(t, amount));
    }
}

using CubeTimerData.Models;
using Microsoft.EntityFrameworkCore;

namespace CubeTimerServices.Services;

public class SolvesService
{
    private CubeTimerContext _context;

    public SolvesService(CubeTimerContext context)
    {
        _context = context;
    }

    public async Task<List<Solves>> GetSolves()
    {
        return await _context.Solves.ToListAsync();
    }

    public async Task<List<Solves>> GetSolvesOfType(CubeTypes Type)
    {
        return await _context.Solves.Where(s => s.Type == Type).ToListAsync();
    }

    public async Task<bool> AddSolve(Solves solve)
    {
        await _context.Solves.AddAsync(solve);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveSolve(int id)
    {
        var solve = await _context.Solves.FirstOrDefaultAsync(s => s.Id == id);

        if (solve != null)
        {
            _context.Solves.Remove(solve);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> UpdateSolve(Solves solve)
    {
        var item = await _context.Solves.FirstOrDefaultAsync(s => s.Id == solve.Id);
        if (item != null)
        {
            item = solve;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}

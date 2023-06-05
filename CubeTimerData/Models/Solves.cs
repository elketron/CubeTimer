
namespace CubeTimerData.Models;

public class Solves
{
    public int Id { get; set; }
    public DateTime SolveTime { get; set; }
    public CubeTypes Type { get; set; }
    public int TimeInSeconds { get; set; }
}

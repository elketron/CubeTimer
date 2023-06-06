using CubeTimerData.Models;

namespace CubeTimerServices.Services;

public class ScramblerService
{
    private List<string> TwoByTwoMoves = new List<string> {
      "U", "F", "R", "U'", "F'", "R'", "U2", "F2", "R2"
    };

    private List<string> Moves = new List<string> {
      "U", "F", "R", "L", "B", "D",
      "U'", "F'", "R'", "L'", "B'", "D'",
      "U2", "F2", "R2", "L2", "B2", "D2",
    };

    public ScramblerService() { }

    public string GetScramble(CubeTypes Type)
    {
        var output = new List<string>();
        var rand = new Random();

        var amountOfMoves = 0;
        if (CubeTypes.TwoByTwo == Type)
        {
            amountOfMoves = rand.Next(5, 11);
        }
        else
        {
            amountOfMoves = (int)Type * 20 + rand.Next(0, 8);
        }

        int movesDone = 0;
        List<string> moves = GeneratePossibleMoves((int)Type);

        while (movesDone <= amountOfMoves)
        {
            string choice = moves[rand.Next(0, moves.Count)];

            //if (output.Count == 0) { continue; }
            try
            {
                if (!check_chars(output[output.Count - 1], choice) || output.Count == 0)
                {
                    output.Add($"{choice} ");
                    movesDone += 1;
                }
            }
            catch
            {
                output.Add(choice);
                movesDone += 1;
            }
        }
        return string.Join(" ", output.ToArray());

    }

    public List<string> GetScrambleAmount(CubeTypes Type, int amount)
    {
        List<string> scrambles = new List<string>();
        for (int i = 0; i <= amount; i++)
        {
            scrambles.Add(GetScramble(Type));
        }
        return scrambles;
    }

    private List<string> GeneratePossibleMoves(int cubeSize)
    {
        if (cubeSize < 3)
        {
            return TwoByTwoMoves;
        }
        else if (cubeSize == 3)
        {
            return Moves;
        }

        var possibleMoves = new List<string>();
        int maxLayer = (int)Math.Floor(cubeSize / 2.0);

        while (maxLayer > 1)
        {
            List<string> result = Moves.Select(x => $"{maxLayer}{x}").ToList();
            possibleMoves.AddRange(result);
            maxLayer -= 1;
        }
        possibleMoves.AddRange(Moves);

        return possibleMoves;
    }

    private bool check_chars(string input, string choice)
    {
        return input.Contains(choice[0]);
    }
}

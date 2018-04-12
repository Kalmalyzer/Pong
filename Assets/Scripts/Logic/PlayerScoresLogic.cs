using System.Linq;

public class PlayerScoresLogic
{
    private readonly int pointsToWin;
    private int[] scores;

    public PlayerScoresLogic(int numPlayers, int pointsToWin)
    {
        this.pointsToWin = pointsToWin;
        scores = new int[numPlayers];
    }

    public int PlayerScore(int playerId)
    {
        return scores[playerId];
    }

    public void Reset()
    {
        for (int playerId = 0; playerId < scores.Length; playerId++)
            scores[playerId] = 0;
    }

    public void AddPoint(int playerId)
    {
        scores[playerId]++;
    }

    public bool MatchOver()
    {
        return scores.Max() >= pointsToWin;
    }
}

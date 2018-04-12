using System;
using System.Linq;

public class PlayerScoresLogic
{
    public Action OnScoreChanged;

    private readonly int pointsToWin;
    private readonly int[] scores;

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

        OnScoreChanged?.Invoke();
    }

    public void AddPoint(int playerId)
    {
        scores[playerId]++;

        OnScoreChanged?.Invoke();
    }

    public bool MatchOver()
    {
        return scores.Max() >= pointsToWin;
    }
}

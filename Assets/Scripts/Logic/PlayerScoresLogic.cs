public class PlayerScoresLogic
{
    private readonly int pointsToWin;

    private int[] scores = new int[2];

    public PlayerScoresLogic(int pointsToWin)
    {
        this.pointsToWin = pointsToWin;
    }

    public int PlayerScore(int playerId)
    {
        return scores[playerId];
    }

    public void Reset()
    {
        for (int playerId = 0; playerId < 2; playerId++)
            scores[playerId] = 0;
    }

    public void AddPoint(int playerId)
    {
        scores[playerId]++;
    }
}

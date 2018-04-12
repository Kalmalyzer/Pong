public class WallLogic
{
    private readonly PlayerScores playerScores;
    private readonly int playerScoreId;

    public WallLogic(PlayerScores playerScores, int playerScoreId)
    {
        this.playerScores = playerScores;
        this.playerScoreId = playerScoreId;
    }

    public void Hit()
    {
        if (playerScores != null)
            playerScores.AddPoint(playerScoreId);
    }
}


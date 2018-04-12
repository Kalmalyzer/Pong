public class WallLogic
{
    private readonly PlayerScoresLogic playerScoresLogic;
    private readonly int playerScoreId;

    public WallLogic(PlayerScoresLogic playerScoresLogic, int playerScoreId)
    {
        this.playerScoresLogic = playerScoresLogic;
        this.playerScoreId = playerScoreId;
    }

    public void Hit()
    {
        if (playerScoresLogic != null)
            playerScoresLogic.AddPoint(playerScoreId);
    }
}


using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour {

    [Header("Static Data")]
    public PlayerScoresData PlayerScoresData;

    private Text scoresText;

    private PlayerScoresLogic playerScoresLogic;

    private string PlayerScoresToString()
    {
        return string.Format("{0} - {1}", playerScoresLogic.PlayerScore(0), playerScoresLogic.PlayerScore(1));
    }

    void Start()
    {
        scoresText = GetComponent<Text>();
        playerScoresLogic = new PlayerScoresLogic(PlayerScoresData.PointsToWin);
        scoresText.text = PlayerScoresToString();
    }

    public void Reset()
    {
        playerScoresLogic.Reset();
        scoresText.text = PlayerScoresToString();
    }

    public bool MatchOver()
    {
        return Mathf.Max(playerScoresLogic.PlayerScore(0), playerScoresLogic.PlayerScore(1)) >= PlayerScoresData.PointsToWin;
    }

    public void AddPoint(int playerId)
    {
        playerScoresLogic.AddPoint(playerId);
        if (playerScoresLogic.PlayerScore(0) >= PlayerScoresData.PointsToWin)
            scoresText.text = string.Format("Winner: Player 1 ({0})", PlayerScoresToString());
        else if (playerScoresLogic.PlayerScore(1) >= PlayerScoresData.PointsToWin)
            scoresText.text = string.Format("Winner: Player 2 ({0})", PlayerScoresToString());
        else
            scoresText.text = PlayerScoresToString();
    }
}

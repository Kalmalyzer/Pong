using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour {

    [Header("Static Data")]
    public PlayerScoresData PlayerScoresData;

    private PlayerScoresLogic playerScoresLogic;
    private PlayerScoresPresentation playerScoresPresentation;

    void Start()
    {
        const int numPlayers = 2;

        playerScoresLogic = new PlayerScoresLogic(numPlayers, PlayerScoresData.PointsToWin);

        Text scoresText = GetComponent<Text>();
        playerScoresPresentation = new PlayerScoresPresentation(playerScoresLogic, PlayerScoresData.PointsToWin, scoresText);
        playerScoresPresentation.UpdateText();
    }

    public void Reset()
    {
        playerScoresLogic.Reset();
        playerScoresPresentation.UpdateText();
    }

    public bool MatchOver()
    {
        return playerScoresLogic.MatchOver();
    }

    public void AddPoint(int playerId)
    {
        playerScoresLogic.AddPoint(playerId);
        playerScoresPresentation.UpdateText();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour {

    [Header("Static Data")]
    public PlayerScoresData PlayerScoresData;

    public PlayerScoresLogic PlayerScoresLogic { get; private set; }
    public PlayerScoresPresentation PlayerScoresPresentation { get; private set; }

    void Start()
    {
        const int numPlayers = 2;

        PlayerScoresLogic = new PlayerScoresLogic(numPlayers, PlayerScoresData.PointsToWin);

        Text scoresText = GetComponent<Text>();
        PlayerScoresPresentation = new PlayerScoresPresentation((visible) => gameObject.SetActive(visible), PlayerScoresLogic, PlayerScoresData.PointsToWin, scoresText);
    }
}

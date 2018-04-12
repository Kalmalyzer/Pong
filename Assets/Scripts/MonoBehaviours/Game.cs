using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour {

    [Header("Static Data")]
    public GameData GameData;

    [Header("References within scene")]
    public GameObject PlayerScores;

    private GameLogic gameLogic;

    void Awake () {
        PlayerScores playerScores = PlayerScores.GetComponent<PlayerScores>();
        gameLogic = new GameLogic((routine) => StartCoroutine(routine), () => Instantiate(GameData.BallPrefab).GetComponent<Ball>().BallLogic, playerScores.PlayerScoresLogic, playerScores.PlayerScoresPresentation, GameData);
	}
}

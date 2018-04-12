using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour {

    [Header("Static Data")]
    public GameData GameData;

    [Header("References within scene")]
    public GameObject PlayerScores;

    private GameLogic gameLogic;

    void Start () {
        gameLogic = new GameLogic((routine) => StartCoroutine(routine), (prefab) => Instantiate(prefab), PlayerScores.GetComponent<PlayerScores>(), GameData);
	}
}

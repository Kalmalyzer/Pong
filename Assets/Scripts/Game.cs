using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour {

    [Header("Static Data")]
    public GameData GameData;

    [Header("References within scene")]
    public GameObject PlayerScores;

    private GameObject liveBall;

    void Start () {

        StartCoroutine(GameFlow());
	}

    private IEnumerator GameFlow()
    {
        while (true)
        {
            PlayerScores.GetComponent<PlayerScores>().Reset();

            while (!PlayerScores.GetComponent<PlayerScores>().MatchOver())
            {
                PlayerScores.SetActive(true);
                yield return new WaitForSeconds(GameData.DelayBetweenBalls);
                PlayerScores.SetActive(false);

                liveBall = Instantiate(GameData.BallPrefab);

                while (liveBall)
                    yield return null;
            }

            PlayerScores.SetActive(true);
            yield return new WaitForSeconds(GameData.DelayBetweenMatches);
            PlayerScores.SetActive(false);
        }
    }
}

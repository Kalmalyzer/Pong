using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject BallPrefab;

    public float DelayBetweenBalls = 1.0f;
    public float DelayBetweenMatches = 1.0f;

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

            while (PlayerScores.GetComponent<PlayerScores>().GetHighestScore() < 3)
            {
                PlayerScores.SetActive(true);
                yield return new WaitForSeconds(DelayBetweenBalls);
                PlayerScores.SetActive(false);

                liveBall = Instantiate(BallPrefab);

                while (liveBall)
                    yield return null;
            }

            PlayerScores.SetActive(true);
            yield return new WaitForSeconds(DelayBetweenMatches);
            PlayerScores.SetActive(false);
        }
    }
}

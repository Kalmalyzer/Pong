using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameObject BallPrefab;

    public float DelayBetweenBalls = 1.0f;

    public GameObject PlayerScores;

    private GameObject liveBall;

    void Start () {

        StartCoroutine(MatchFlow());
	}

    private IEnumerator MatchFlow()
    {
        while (true)
        {
            PlayerScores.SetActive(true);
            yield return new WaitForSeconds(DelayBetweenBalls);
            PlayerScores.SetActive(false);

            liveBall = Instantiate(BallPrefab);

            while (liveBall)
                yield return null;
        }
    }
}

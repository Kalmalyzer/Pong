using System.Collections;
using UnityEngine;

public class GameLogic
{
    public delegate void StartCoroutineDelegate(IEnumerator routine);
    public delegate GameObject InstantiateDelegate(GameObject prefab);

    private readonly StartCoroutineDelegate startCoroutine;
    private readonly InstantiateDelegate instantiate;
    private readonly PlayerScores playerScores;
    private readonly GameData gameData;

    public GameLogic(StartCoroutineDelegate startCoroutine, InstantiateDelegate instantiate, PlayerScores playerScores, GameData gameData)
    {
        this.startCoroutine = startCoroutine;
        this.gameData = gameData;

        startCoroutine(GameFlow());
    }

    private IEnumerator GameFlow()
    {
        while (true)
        {
            playerScores.Reset();

            while (!playerScores.MatchOver())
            {
                playerScores.Display(true);
                yield return new WaitForSeconds(gameData.DelayBetweenBalls);
                playerScores.Display(false);

                GameObject liveBall = instantiate(gameData.BallPrefab);

                while (liveBall)
                    yield return null;
            }

            playerScores.Display(true);
            yield return new WaitForSeconds(gameData.DelayBetweenMatches);
            playerScores.Display(true);
        }
    }
}

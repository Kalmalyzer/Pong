using System.Collections;
using UnityEngine;

public class GameLogic
{
    public delegate void StartCoroutineDelegate(IEnumerator routine);
    public delegate GameObject InstantiateDelegate(GameObject prefab);

    private readonly StartCoroutineDelegate startCoroutine;
    private readonly InstantiateDelegate instantiate;
    private readonly PlayerScoresLogic playerScoresLogic;
    private readonly PlayerScoresPresentation playerScoresPresentation;
    private readonly GameData gameData;

    public GameLogic(StartCoroutineDelegate startCoroutine, InstantiateDelegate instantiate, PlayerScoresLogic playerScoresLogic, PlayerScoresPresentation playerScoresPresentation, GameData gameData)
    {
        this.startCoroutine = startCoroutine;
        this.instantiate = instantiate;
        this.playerScoresLogic = playerScoresLogic;
        this.playerScoresPresentation = playerScoresPresentation;
        this.gameData = gameData;

        startCoroutine(GameFlow());
    }

    private IEnumerator GameFlow()
    {
        while (true)
        {
            playerScoresLogic.Reset();

            while (!playerScoresLogic.MatchOver())
            {
                playerScoresPresentation.Display(true);
                yield return new WaitForSeconds(gameData.DelayBetweenBalls);
                playerScoresPresentation.Display(false);

                GameObject liveBall = instantiate(gameData.BallPrefab);

                while (liveBall)
                    yield return null;
            }

            playerScoresPresentation.Display(true);
            yield return new WaitForSeconds(gameData.DelayBetweenMatches);
            playerScoresPresentation.Display(true);
        }
    }
}

using System.Collections;
using UnityEngine;

public class GameLogic
{
    public delegate void StartCoroutineDelegate(IEnumerator routine);
    public delegate BallLogic CreateBallDelegate();

    private readonly StartCoroutineDelegate startCoroutine;
    private readonly CreateBallDelegate createBall;
    private readonly PlayerScoresLogic playerScoresLogic;
    private readonly PlayerScoresPresentation playerScoresPresentation;
    private readonly GameData gameData;

    public GameLogic(StartCoroutineDelegate startCoroutine, CreateBallDelegate createBall, PlayerScoresLogic playerScoresLogic, PlayerScoresPresentation playerScoresPresentation, GameData gameData)
    {
        this.startCoroutine = startCoroutine;
        this.createBall = createBall;
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

                bool ballIsAlive = true;

                BallLogic ballLogic = createBall();
                ballLogic.OnDestroyed += () => ballIsAlive = false;

                while (ballIsAlive)
                    yield return null;
            }

            playerScoresPresentation.Display(true);
            yield return new WaitForSeconds(gameData.DelayBetweenMatches);
            playerScoresPresentation.Display(true);
        }
    }
}

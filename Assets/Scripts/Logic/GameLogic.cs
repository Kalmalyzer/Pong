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

    private IEnumerator DisplayScores(float delay)
    {
        playerScoresPresentation.Display(true);
        yield return new WaitForSeconds(delay);
        playerScoresPresentation.Display(false);
    }

    private IEnumerator BallFlow()
    {
        bool ballIsAlive = true;

        BallLogic ballLogic = createBall();
        ballLogic.OnDestroyed += () => ballIsAlive = false;

        while (ballIsAlive)
            yield return null;
    }

    private IEnumerator GameFlow()
    {
        while (true)
        {
            playerScoresLogic.Reset();

            while (!playerScoresLogic.MatchOver())
            {
                yield return DisplayScores(gameData.DelayBetweenBalls);

                yield return BallFlow();
            }

            yield return DisplayScores(gameData.DelayBetweenMatches);
        }
    }
}

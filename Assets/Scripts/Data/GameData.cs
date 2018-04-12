using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData", order = 1100)]
public class GameData : ScriptableObject
{
    public float DelayBetweenBalls = 1.0f;
    public float DelayBetweenMatches = 1.0f;

    public GameObject BallPrefab;
}

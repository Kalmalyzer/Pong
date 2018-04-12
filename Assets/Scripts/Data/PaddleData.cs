using UnityEngine;

[CreateAssetMenu(fileName = "PaddleData", menuName = "PaddleData", order = 1100)]
public class PaddleData : ScriptableObject
{
    public float MovementSpeedScaleFactor;
    public float PositionScale;
}

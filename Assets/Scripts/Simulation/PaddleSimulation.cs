using UnityEngine;

public class PaddleSimulation
{
    private float yPosition;

    public float UpdatePosition(float inputAxisReading, float movementSpeedScaleFactor, float deltaTime)
    {
        float delta = inputAxisReading * movementSpeedScaleFactor * deltaTime;
        yPosition = Mathf.Clamp(yPosition + delta, -1, 1);

        return yPosition;
    }
}

using UnityEngine;

public class BallSimulation
{
    private Vector3 velocity;

    public BallSimulation(Vector3 initialVelocity)
    {
        velocity = initialVelocity;
    }

    public Vector3 UpdatePosition(Vector3 currentPosition, float deltaTime)
    {
        return currentPosition + velocity * deltaTime;
    }

    public void ReflectVelocityVertically()
    {
        velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
    }

    public void ReflectVelocityHorizontally()
    {
        velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
    }
}

using UnityEngine;

public class BallLogic
{
    public delegate void NoLongerAliveDelegate();

    private readonly BallSimulation ballSimulation;
    private readonly Transform transform;
    private readonly NoLongerAliveDelegate noLongerAlive;

    public BallLogic(Transform transform, BallSimulation ballSimulation, NoLongerAliveDelegate noLongerAlive)
    {
        this.transform = transform;
        this.ballSimulation = ballSimulation;
        this.noLongerAlive = noLongerAlive;
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        transform.localPosition = ballSimulation.UpdatePosition(transform.localPosition, Time.fixedDeltaTime);
    }

    public void Hit(string tag)
    {
        if (tag == "HorizontalWall")
            ballSimulation.ReflectVelocityVertically();
        if (tag == "VerticalWall")
            noLongerAlive();
        if (tag == "Paddle")
            ballSimulation.ReflectVelocityHorizontally();
    }
}

using UnityEngine;

public class BallLogic
{
    public delegate Vector3 GetLocalPositionDelegate();
    public delegate void SetLocalPositionDelegate(Vector3 localPosition);
    public delegate void NoLongerAliveDelegate();

    private readonly BallSimulation ballSimulation;
    private readonly GetLocalPositionDelegate getLocalPosition;
    private readonly SetLocalPositionDelegate setLocalPosition;
    private readonly NoLongerAliveDelegate noLongerAlive;

    public BallLogic(GetLocalPositionDelegate getLocalPosition, SetLocalPositionDelegate setLocalPosition, BallSimulation ballSimulation, NoLongerAliveDelegate noLongerAlive)
    {
        this.getLocalPosition = getLocalPosition;
        this.setLocalPosition = setLocalPosition;
        this.ballSimulation = ballSimulation;
        this.noLongerAlive = noLongerAlive;
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        Vector3 newPosition = ballSimulation.UpdatePosition(getLocalPosition(), Time.fixedDeltaTime);
        setLocalPosition(newPosition);
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

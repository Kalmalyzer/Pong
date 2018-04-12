using System;
using UnityEngine;

public class BallLogic
{
    public delegate Vector3 GetLocalPositionDelegate();
    public delegate void SetLocalPositionDelegate(Vector3 localPosition);

    public Action OnDestroyed;

    private readonly BallSimulation ballSimulation;
    private readonly GetLocalPositionDelegate getLocalPosition;
    private readonly SetLocalPositionDelegate setLocalPosition;

    public BallLogic(GetLocalPositionDelegate getLocalPosition, SetLocalPositionDelegate setLocalPosition, BallSimulation ballSimulation)
    {
        this.getLocalPosition = getLocalPosition;
        this.setLocalPosition = setLocalPosition;
        this.ballSimulation = ballSimulation;
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
            OnDestroyed();
        if (tag == "Paddle")
            ballSimulation.ReflectVelocityHorizontally();
    }
}

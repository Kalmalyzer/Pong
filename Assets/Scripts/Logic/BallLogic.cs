using System;
using UnityEngine;

public class BallLogic
{
    public Action OnDestroyed;

    private readonly BallSimulation ballSimulation;
    private readonly ILocalPositionAdapter localPositionAdapter;

    public BallLogic(ILocalPositionAdapter localPositionAdapter, BallSimulation ballSimulation)
    {
        this.localPositionAdapter = localPositionAdapter;
        this.ballSimulation = ballSimulation;
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        Vector3 newPosition = ballSimulation.UpdatePosition(localPositionAdapter.LocalPosition, Time.fixedDeltaTime);
        localPositionAdapter.LocalPosition = newPosition;
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

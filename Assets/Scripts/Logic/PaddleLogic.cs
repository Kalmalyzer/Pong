using UnityEngine;

public class PaddleLogic
{
    private readonly IPositionAdapter positionAdapter;
    private readonly PaddleData paddleData;
    private readonly PaddleInput paddleInput;
    private readonly PaddleSimulation paddleSimulation;

    public PaddleLogic(IPositionAdapter positionAdapter, PaddleData paddleData, PaddleInput paddleInput, PaddleSimulation paddleSimulation)
    {
        this.positionAdapter = positionAdapter;
        this.paddleData = paddleData;
        this.paddleInput = paddleInput;
        this.paddleSimulation = paddleSimulation;
    }

    public void Update(float deltaTime)
    {
        float inputAxisReading = paddleInput.ReadInput();

        float yPosition = paddleSimulation.UpdatePosition(inputAxisReading, paddleData.MovementSpeedScaleFactor, Time.deltaTime);

        Vector3 oldPosition = positionAdapter.Position;
        Vector3 newPosition = new Vector3(oldPosition.x, yPosition * paddleData.PositionScale, oldPosition.z);
        positionAdapter.Position = newPosition;
    }
}

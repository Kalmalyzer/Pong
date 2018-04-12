using UnityEngine;

public class PaddleLogic
{
    public delegate Vector3 GetPositionDelegate();
    public delegate void SetPositionDelegate(Vector3 position);

    private readonly GetPositionDelegate getPosition;
    private readonly SetPositionDelegate setPosition;
    private readonly PaddleData paddleData;
    private readonly PaddleInput paddleInput;
    private readonly PaddleSimulation paddleSimulation;

    public PaddleLogic(GetPositionDelegate getPosition, SetPositionDelegate setPosition, PaddleData paddleData, PaddleInput paddleInput, PaddleSimulation paddleSimulation)
    {
        this.getPosition = getPosition;
        this.setPosition = setPosition;
        this.paddleData = paddleData;
        this.paddleInput = paddleInput;
        this.paddleSimulation = paddleSimulation;
    }

    public void Update(float deltaTime)
    {
        float inputAxisReading = paddleInput.ReadInput();

        float yPosition = paddleSimulation.UpdatePosition(inputAxisReading, paddleData.MovementSpeedScaleFactor, Time.deltaTime);

        Vector3 oldPosition = getPosition();
        Vector3 newPosition = new Vector3(oldPosition.x, yPosition * paddleData.PositionScale, oldPosition.z);
        setPosition(newPosition);
    }
}

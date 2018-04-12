using UnityEngine;

public class PaddleLogic
{
    private readonly Transform transform;
    private readonly PaddleData paddleData;
    private readonly PaddleInput paddleInput;
    private readonly PaddleSimulation paddleSimulation;

    public PaddleLogic(Transform transform, PaddleData paddleData, PaddleInput paddleInput, PaddleSimulation paddleSimulation)
    {
        this.transform = transform;
        this.paddleData = paddleData;
        this.paddleInput = paddleInput;
        this.paddleSimulation = paddleSimulation;
    }

    public void Update(float deltaTime)
    {
        float inputAxisReading = paddleInput.ReadInput();

        float yPosition = paddleSimulation.UpdatePosition(inputAxisReading, paddleData.MovementSpeedScaleFactor, Time.deltaTime);

        transform.position = new Vector3(transform.position.x, yPosition * paddleData.PositionScale, transform.position.z);
    }
}

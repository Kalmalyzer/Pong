using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Static Data")]
    public PaddleData PaddleData;

    [Header("Customizable settings")]
    public string InputAxisName;

    private MeshRenderer mesh;
    private AudioSource bounceSfx;

    private PaddleInput paddleInput;
    private PaddleSimulation paddleSimulation;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        bounceSfx = GetComponent<AudioSource>();

        paddleInput = new PaddleInput(InputAxisName);
        paddleSimulation = new PaddleSimulation();
    }

    void Update()
    {
        float inputAxisReading = paddleInput.ReadInput();

        float yPosition = paddleSimulation.UpdatePosition(inputAxisReading, PaddleData.MovementSpeedScaleFactor, Time.deltaTime);

        transform.position = new Vector3(transform.position.x, yPosition * PaddleData.PositionScale, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceSfx.Play();
    }
}

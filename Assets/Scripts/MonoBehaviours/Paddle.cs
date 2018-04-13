using UnityEngine;

public class Paddle : MonoBehaviour, IPositionAdapter
{
    [Header("Static Data")]
    public PaddleData PaddleData;

    [Header("Customizable settings")]
    public string InputAxisName;

    private AudioSource bounceSfx;

    private PaddleInput paddleInput;
    private PaddleSimulation paddleSimulation;
    private PaddleLogic paddleLogic;

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Awake()
    {
        bounceSfx = GetComponent<AudioSource>();

        paddleInput = new PaddleInput(InputAxisName);
        paddleSimulation = new PaddleSimulation();
        paddleLogic = new PaddleLogic(this, PaddleData, paddleInput, paddleSimulation);
    }

    void Update()
    {
        paddleLogic.Update(Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceSfx.Play();
    }
}

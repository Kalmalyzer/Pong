using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Static Data")]
    public PaddleData PaddleData;

    [Header("Customizable settings")]
    public string InputAxisName;

    private AudioSource bounceSfx;

    private PaddleInput paddleInput;
    private PaddleSimulation paddleSimulation;
    private PaddleLogic paddleLogic;

    void Start()
    {
        bounceSfx = GetComponent<AudioSource>();

        paddleInput = new PaddleInput(InputAxisName);
        paddleSimulation = new PaddleSimulation();
        paddleLogic = new PaddleLogic(() => transform.position, (position) => transform.position = position, PaddleData, paddleInput, paddleSimulation);
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

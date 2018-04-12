using UnityEngine;

public class Paddle : MonoBehaviour
{
    public PaddleData PaddleData;

    public string InputAxisName;

    private float yPosition;
    private MeshRenderer mesh;
    private AudioSource bounceSfx;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        bounceSfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        float delta = Input.GetAxis(InputAxisName) * PaddleData.MovementSpeedScaleFactor * Time.deltaTime;
        yPosition = Mathf.Clamp(yPosition + delta, -1, 1);

        transform.position = new Vector3(transform.position.x, yPosition * PaddleData.PositionScale, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceSfx.Play();
    }
}

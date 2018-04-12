using UnityEngine;

public class Paddle : MonoBehaviour
{
    public string InputAxisName;
    public float MovementSpeedScaleFactor;
    public float PositionScale;

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
        float delta = Input.GetAxis(InputAxisName) * MovementSpeedScaleFactor * Time.deltaTime;
        yPosition = Mathf.Clamp(yPosition + delta, -1, 1);

        transform.position = new Vector3(transform.position.x, yPosition * PositionScale, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceSfx.Play();
    }
}

using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour {

    [Header("Customizable per instance")]
    [FormerlySerializedAs("Velocity")]
    public Vector3 InitialVelocity;

    private BallSimulation ballSimulation;

    void Start()
    {
        ballSimulation = new BallSimulation(InitialVelocity);
    }

    void FixedUpdate()
    {
        transform.localPosition = ballSimulation.UpdatePosition(transform.localPosition, Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "HorizontalWall")
            ballSimulation.ReflectVelocityVertically();
        if (collider.gameObject.tag == "VerticalWall")
            Destroy(gameObject);
        if (collider.gameObject.tag == "Paddle")
            ballSimulation.ReflectVelocityHorizontally();
    }
}

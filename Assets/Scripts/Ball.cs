using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour {

    [Header("Customizable per instance")]
    [FormerlySerializedAs("Velocity")]
    public Vector3 InitialVelocity;

    private BallLogic ballLogic;
    private BallSimulation ballSimulation;

    void Start()
    {
        ballSimulation = new BallSimulation(InitialVelocity);
        ballLogic = new BallLogic(ballSimulation);
    }

    void FixedUpdate()
    {
        transform.localPosition = ballSimulation.UpdatePosition(transform.localPosition, Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        bool isAlive = ballLogic.Hit(collider.gameObject.tag);
        if (!isAlive)
            Destroy(gameObject);
    }
}

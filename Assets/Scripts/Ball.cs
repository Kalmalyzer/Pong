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
        ballLogic = new BallLogic(transform, ballSimulation, () => Destroy(gameObject));
    }

    void FixedUpdate()
    {
        ballLogic.FixedUpdate(Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        ballLogic.Hit(collider.gameObject.tag);
    }
}

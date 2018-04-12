using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour {

    [Header("Customizable per instance")]
    [FormerlySerializedAs("Velocity")]
    public Vector3 InitialVelocity;

    public BallLogic BallLogic { get; private set; }
    private BallSimulation ballSimulation;

    void Awake()
    {
        ballSimulation = new BallSimulation(InitialVelocity);
        BallLogic = new BallLogic(() => transform.localPosition, (localPosition) => transform.localPosition = localPosition, ballSimulation);
        BallLogic.OnDestroyed += () => Destroy(gameObject);
    }

    void FixedUpdate()
    {
        BallLogic.FixedUpdate(Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        BallLogic.Hit(collider.gameObject.tag);
    }
}

using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour, ILocalPositionAdapter {

    [Header("Customizable per instance")]
    [FormerlySerializedAs("Velocity")]
    public Vector3 InitialVelocity;

    public BallLogic BallLogic { get; private set; }
    private BallSimulation ballSimulation;

    public Vector3 LocalPosition
    {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    void Awake()
    {
        ballSimulation = new BallSimulation(InitialVelocity);
        BallLogic = new BallLogic(this, ballSimulation);
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

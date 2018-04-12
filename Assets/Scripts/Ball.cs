using UnityEngine;

public class Ball : MonoBehaviour {

    [Header("Customizable per instance")]
    public Vector3 Velocity;

    void FixedUpdate()
    {
        transform.localPosition = transform.localPosition + Velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "HorizontalWall")
            Velocity = new Vector3(Velocity.x, -Velocity.y, Velocity.z);
        if (collider.gameObject.tag == "VerticalWall")
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Paddle")
            Velocity = new Vector3(-Velocity.x, Velocity.y, Velocity.z);
    }
}

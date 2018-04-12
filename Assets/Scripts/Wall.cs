using UnityEngine;

public class Wall : MonoBehaviour {

    private AudioSource bounceSfx;

    void Start()
    {
        bounceSfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceSfx.Play();
    }
}

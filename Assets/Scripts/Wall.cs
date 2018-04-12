using UnityEngine;

public class Wall : MonoBehaviour {

    [Header("References within scene")]
    public PlayerScores PlayerScores;

    [Header("Customizable per instance")]
    public int PlayerScoreId;

    private AudioSource bounceSfx;

    void Start()
    {
        bounceSfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceSfx.Play();

        if (PlayerScores != null)
            PlayerScores.AddPoint(PlayerScoreId);
    }
}

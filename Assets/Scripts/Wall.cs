using UnityEngine;

public class Wall : MonoBehaviour {

    public PlayerScores PlayerScores;
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

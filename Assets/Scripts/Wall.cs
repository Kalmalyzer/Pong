using UnityEngine;

public class Wall : MonoBehaviour {

    [Header("References within scene")]
    public PlayerScores PlayerScores;

    [Header("Customizable per instance")]
    public int PlayerScoreId;

    private AudioSource bounceSfx;

    private WallLogic wallLogic;

    void Start()
    {
        bounceSfx = GetComponent<AudioSource>();

        wallLogic = new WallLogic(PlayerScores?.PlayerScoresLogic, PlayerScoreId);
    }

    private void OnTriggerEnter(Collider other)
    {
        wallLogic.Hit();

        bounceSfx.Play();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour {

    private int[] Scores = new int[2];

    private Text scoresText;

    void Start()
    {
        scoresText = GetComponent<Text>();
        scoresText.text = string.Format("{0} - {1}", Scores[0], Scores[1]);
    }

    public void AddPoint(int playerId)
    {
        Scores[playerId]++;
        scoresText.text = string.Format("{0} - {1}", Scores[0], Scores[1]);
    }
}

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

    public void Reset()
    {
        for (int i = 0; i < 2; i++)
            Scores[i] = 0;
        scoresText.text = string.Format("{0} - {1}", Scores[0], Scores[1]);
    }

    public int GetHighestScore()
    {
        return Mathf.Max(Scores[0], Scores[1]);
    }

    public void AddPoint(int playerId)
    {
        Scores[playerId]++;
        if (Scores[0] >= 3)
            scoresText.text = string.Format("Winner: Player 1 ({0} - {1})", Scores[0], Scores[1]);
        else if (Scores[1] >= 3)
            scoresText.text = string.Format("Winner: Player 2 ({0} - {1})", Scores[0], Scores[1]);
        else
            scoresText.text = string.Format("{0} - {1}", Scores[0], Scores[1]);
    }
}

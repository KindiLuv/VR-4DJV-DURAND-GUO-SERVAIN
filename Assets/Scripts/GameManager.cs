using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        resetScore();
        syncScoreUI();
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        syncScoreUI();
    }

    public void resetScore()
    {
        score = 0;
        syncScoreUI();
    }

    public void syncScoreUI()
    {
        scoreText.text = score.ToString();
    }
}

using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    private SwitchScene switchSceneScript;
    public bool t;
    public bool tt;
    public bool ttt;

    private void Start()
    {
        switchSceneScript = GetComponent<SwitchScene>();
        switchSceneScript.ChangeScene(1);
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

    private void Update()
    {
        if(t)
        {
            switchSceneScript.RemoveScene();
            switchSceneScript.ChangeScene(2);
            t = false;
        }
        
        if(tt)
        {
            switchSceneScript.RemoveScene();
            switchSceneScript.ChangeScene(3);
            tt = false;
        }
        
        if(ttt)
        {
            switchSceneScript.RemoveScene();
            switchSceneScript.ChangeScene(4);
            ttt = false;
        }
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    private SwitchScene switchSceneScript;
    public bool t;
    public bool tt;
    public bool ttt;
    [SerializeField] private TextMeshProUGUI TargetCounterText;
    private int TotaltargetNumber;
    private int targetNumber;

    private void Start()
    {
        switchSceneScript = GetComponent<SwitchScene>();
        switchSceneScript.ChangeScene(1);
        LoadTarget();
        syncUI();
    }

    public void DecrementTarget()
    {
        targetNumber--;
        syncUI();
    }
    public void syncUI()
    {
        TargetCounterText.text = targetNumber.ToString()+"/"+TotaltargetNumber.ToString();
    }

    public void LoadTarget()
    {
        TotaltargetNumber = FindObjectsOfType<ArcheryTarget>().Length;
        targetNumber = TotaltargetNumber;
        syncUI();
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

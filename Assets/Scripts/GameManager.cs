using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    private SwitchScene switchSceneScript;
    [SerializeField] private TextMeshProUGUI TargetCounterText;
    private int TotaltargetNumber;
    public int targetNumber = 7;

    private IEnumerator Start()
    {
        switchSceneScript = GetComponent<SwitchScene>();
        switchSceneScript.ChangeScene(1);
        yield return new WaitUntil( () => switchSceneScript.init);
        LoadTarget(7);
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

    public void LoadTarget(int targetNb)
    {
        TotaltargetNumber = targetNb;
        targetNumber = TotaltargetNumber;
        syncUI();
    }

    private void Update()
    {
        Debug.LogError(targetNumber);
        if (targetNumber == 0)
        {
            Debug.LogError("target was 0");
            switch (switchSceneScript.actualScene)
            {
                case 1:
                    switchSceneScript.RemoveScene();
                    switchSceneScript.ChangeScene(2);
                    LoadTarget(5);
                    break;
                case 2:
                    switchSceneScript.RemoveScene();
                    switchSceneScript.ChangeScene(1);
                    LoadTarget(7);
                    break;
            }
        }
    }
}

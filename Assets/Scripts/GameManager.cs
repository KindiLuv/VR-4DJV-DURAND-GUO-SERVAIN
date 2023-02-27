using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SwitchScene switchSceneScript;
    [SerializeField] private TextMeshPro TargetCounterText;
    private int TotaltargetNumber = 7;
    public int targetNumber = 7;

    private IEnumerator Start()
    {
        switchSceneScript = GetComponent<SwitchScene>();
        switchSceneScript.ChangeScene(1);
        yield return new WaitUntil( () => switchSceneScript.init);
        LoadTarget(7);
    }

    public void DecrementTarget()
    {
        targetNumber--;
        syncUI();
    }
    private void syncUI()
    {
        TargetCounterText.SetText(targetNumber.ToString()+"/"+TotaltargetNumber.ToString());
    }

    public void LoadTarget(int targetNb)
    {
        TotaltargetNumber = targetNb;
        targetNumber = TotaltargetNumber;
        syncUI();
    }

    private void Update()
    {
        if (targetNumber == 0)
        {
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

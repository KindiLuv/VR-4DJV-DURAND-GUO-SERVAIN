using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TargetCounterText;
    private int TotaltargetNumber;
    private int targetNumber;

    private void Start()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
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
}

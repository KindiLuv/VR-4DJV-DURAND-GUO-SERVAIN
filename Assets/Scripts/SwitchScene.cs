using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{ 
    private int actualScene;

    public void RemoveScene()
    {
        SceneManager.UnloadSceneAsync(actualScene);
    }
    
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        actualScene = scene;
    }
}

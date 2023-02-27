using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{ 
    public int actualScene;
    public bool init;

    public void RemoveScene()
    {
        SceneManager.UnloadSceneAsync(actualScene);
    }
    
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        actualScene = scene;
        init = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void LoadScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(1);//Async(SceneManager.GetActiveScene().name);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}

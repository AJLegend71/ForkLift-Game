using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneLoader : MonoBehaviour
{
    [Header("Set in Inspector")]
    public string sceneToLoad;
    void start()
    {

    }

   public void sceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
   public  void resume()
    {
        SceneTransition.pauseScreen = false;
        SceneManager.UnloadSceneAsync("_EscMenu");
        Time.timeScale = 1;
    }

   public void exit()
   {
     Application.Quit();
   }
}

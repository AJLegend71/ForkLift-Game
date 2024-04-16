using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
 
    static public bool pauseScreen = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //load pause & unload
            if(pauseScreen == false)
            {
            SceneManager.LoadScene ("_EscMenu", LoadSceneMode.Additive);
            pauseScreen = true;
            pauseGame();
            }
            else
            {
             resume();
            }
        }
    }

    public void resume()
    {
        pauseScreen = false;
        SceneManager.UnloadSceneAsync("_EscMenu");
        resumeGame();
    }

     public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }
}

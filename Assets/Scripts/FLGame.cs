using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FLGame : MonoBehaviour
{
    int numGoals;
    public GameObject [] Gls;
    public bool escMenu = false;
    private Text gt;
    [Header("Set in Inspector")]
    public GameObject boxPrefab;
    public string sceneToLoad;
    public float timeLimit = 80f;
    void Start()
    {
        Gls = null;
        numGoals = 0;
        Gls = GameObject.FindGameObjectsWithTag("Goal");
        gt = GameObject.Find("TimeLeft").GetComponent<Text>();
        gt.text = "Time:" + timeLimit;
        timeLimit = timeLimit + Time.time;
        foreach(GameObject g in Gls)
        {
            numGoals++;
        }

        spawnBoxes();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if time = 0, done, if goals met done
        bool finished = true;
        
        foreach(GameObject g in Gls)
        {
          
          if(g.GetComponent<Goal>().goalMet == false)
          {
            finished = false;
          }

        }
        if(finished != true)
        {
        gt = GameObject.Find("TimeLeft").GetComponent<Text>();
        gt.text = "Time: " + (int)(timeLimit - Time.time);
        }

        if(finished == true)
        {
            gt = GameObject.Find("TimeLeft").GetComponent<Text>();
            gt.text = "COMPLETE";
            timeLimit = timeLimit + 10f;
            Invoke("sceneCall",5f);
            print("Next Mission");
        }
        else if(timeLimit <= Time.time)
        {
            print("Game Over/ Failed");
            failCall();
        }

    }

    void spawnBoxes()
    {
        float space = 0;
        float temp = 0f;
        for( int i = 0; i < numGoals; ++ i)
        {
        space = 0f;
        space = Random.Range(-15f,15f);
        while(temp == space || (space < 3f  && space > -3f))
        {
         space = Random.Range(-15f,15f);
        }
        Vector3 vec  = new Vector3(space,2.5f * i+1,0);
        GameObject box = Instantiate<GameObject>(boxPrefab);
        box.transform.position = vec;
        temp = space;
        }
    }

    void sceneCall()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void failCall()
    {
        SceneManager.LoadScene("_Failed");
    }

}

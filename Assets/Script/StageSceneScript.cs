using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {


        SceneManager.LoadScene("Stage1");
    }
    public void StartButton1()
    {


        SceneManager.LoadScene("Stage2");
    }
    public void StartButton2()
    {


        SceneManager.LoadScene("Stage3");
    }


}


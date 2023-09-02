using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DemoStart : MonoBehaviour
{

    public SturgeonForward forward;
    private bool pause;
    public GameObject pauseMenu;
    public void restartButton()
    {
        SceneManager.LoadScene("RiverScene");
    }
    
    public void menuButton()
    {
        SceneManager.LoadScene("RiverScene 1");
    }

    public void startGame()
    {
        SceneManager.LoadScene("RiverScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
            }
        }
    }
}

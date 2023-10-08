using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused;
    CanvasGroup canvas;
    //public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0f;
            gamePaused = true;
            AudioListener.pause = true;
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }
        else if (gamePaused == true)
        {
            ResumeGame();
        }


    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
        AudioListener.pause = false;
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

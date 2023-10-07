using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup canvas;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        canvas.alpha = 1;
        canvas.interactable = true;
        menu.SetActive(true);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        canvas.alpha = 0;
        canvas.interactable = false;
        menu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

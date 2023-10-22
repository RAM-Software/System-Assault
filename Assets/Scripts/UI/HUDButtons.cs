using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HUDButtons : MonoBehaviour
{
    public bool gamePaused;
    public bool troopsVisible;
    public bool volumeShown;
    CanvasGroup canvas;
    public GameObject pauseMenu;
    public GameObject troopButtons;
    public GameObject volumeMenu;
    public GameObject showTroopsButton;
    //public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        troopsVisible = false;
        gamePaused = false;
        volumeShown = false;
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
            pauseMenu.SetActive(true);
            //canvas.alpha = 1;
            //canvas.interactable = true;
            //canvas.blocksRaycasts = true;
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
        pauseMenu.SetActive(false);
        //canvas.alpha = 0;
        //canvas.interactable = false;
        //canvas.blocksRaycasts = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void ShowTroops()
    {
        if (troopsVisible == false)
        {
            troopButtons.SetActive(true);
            troopsVisible = true;
        }
        else if (troopsVisible == true)
        {
            troopButtons.SetActive(false);
            troopsVisible = false;
        }
    }

    public void showVolume()
    {
        if (volumeShown == false)

        {
            volumeMenu.SetActive(true);
            volumeShown = true;
            pauseMenu.SetActive(false);
        }
        else if (volumeShown == true)
        {
            volumeMenu.SetActive(false);
            volumeShown = false;
            pauseMenu.SetActive(true);
        }
    }

}


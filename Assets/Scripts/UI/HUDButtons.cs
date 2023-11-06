using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HUDButtons : MonoBehaviour
{
    public bool gamePaused;
    public bool troopsVisible;
    public bool junkInfoVisible;
    public bool mailInfoVisible;
    public bool zipInfoVisible;
    public bool volumeShown;
    CanvasGroup canvas;
    public GameObject pauseMenu;
    public GameObject troopButtons;
    public GameObject volumeMenu;
    public GameObject showTroopsButton;
    public GameObject JunkInfo;
    public GameObject MailInfo;
    public GameObject ZipInfo;
    public GameObject LevelInfoText;
    //public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        troopsVisible = false;
        gamePaused = false;
        volumeShown = false;
        canvas = GetComponent<CanvasGroup>();
        Invoke("turnOffLevelInfo", 5.0f);
    }
    private void Awake()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void turnOffLevelInfo()
    {
        LevelInfoText.SetActive(false);
    }

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            gamePaused = true;
            Time.timeScale = 0f;
            //AudioListener.pause = true;
            pauseMenu.SetActive(true);
            troopButtons.SetActive(false);
            LevelInfoText.SetActive(false);
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
        gamePaused = false;
        Time.timeScale = 1;
        //AudioListener.pause = false;
        pauseMenu.SetActive(false);
        troopButtons.SetActive(true);
        JunkInfo.SetActive(false);
        MailInfo.SetActive(false);
        ZipInfo.SetActive(false);
        volumeMenu.SetActive(false);
        //canvas.alpha = 0;
        //canvas.interactable = false;
        //canvas.blocksRaycasts = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
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
            JunkInfo.SetActive(false);
            MailInfo.SetActive(false);
            ZipInfo.SetActive(false);
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

    public void junkInfoButton()
    {
        if (junkInfoVisible == false)
        {
            JunkInfo.SetActive(true);
            junkInfoVisible = true;
        }
        else if (junkInfoVisible == true)
        {
            JunkInfo.SetActive(false);
            junkInfoVisible = false;
        }
    }

    public void mailInfoButton()
    {
        if (mailInfoVisible == false)
        {
            MailInfo.SetActive(true);
            mailInfoVisible = true;
        }
        else if (mailInfoVisible == true)
        {
            MailInfo.SetActive(false);
            mailInfoVisible = false;
        }
    }

    public void zipInfoButton()
    {
        if (zipInfoVisible == false)
        {
            ZipInfo.SetActive(true);
            zipInfoVisible = true;
        }
        else if (zipInfoVisible == true)
        {
            ZipInfo.SetActive(false);
            zipInfoVisible = false;
        }
    }

}


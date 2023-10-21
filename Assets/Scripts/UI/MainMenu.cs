using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject LevelSelectButtons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {

    }
    
    public void MainMenuSelect()
    {
        MainButtons.SetActive(true);
        LevelSelectButtons.SetActive(false);
    }

    public void LevelSelectMenu()
    {
        MainButtons.SetActive(false);
        LevelSelectButtons.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect1()
    {
        SceneManager.LoadScene("Level1Scene");
    }
    public void LevelSelect2()
    {
        SceneManager.LoadScene("Level2Scene");
    }
    public void LevelSelect3()
    {
        SceneManager.LoadScene("Level3Scene");
    }
    public void LevelSelect4()
    {
        SceneManager.LoadScene("Level4Scene");
    }
    public void LevelSelect5()
    {
        SceneManager.LoadScene("Level5Scene");
    }
}

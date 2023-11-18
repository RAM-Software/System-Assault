using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject LevelSelectButtons;
    public GameObject Shop;
    public GameObject Credits;
    public GameObject Options;
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

    public void OptionsMenu()
    {
        Options.SetActive(true);
        MainButtons.SetActive(false);
        LevelSelectButtons.SetActive(false);
        Shop.SetActive(false);
        Credits.SetActive(false);
    }
    
    public void MainMenuSelect()
    {
        MainButtons.SetActive(true);
        LevelSelectButtons.SetActive(false);
        Shop.SetActive(false);
        Credits.SetActive(false);
        Options.SetActive(false);
    }

    public void LevelSelectMenu()
    {
        MainButtons.SetActive(false);
        LevelSelectButtons.SetActive(true);
    }

    public void CreditsMenu()
    {
        Credits.SetActive(true);
        Options.SetActive(false);
        MainButtons.SetActive(false);
        LevelSelectButtons.SetActive(false);
        Shop.SetActive(false);

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

    public void ShopMenu()
    {
        Shop.SetActive(true);
        MainButtons.SetActive(false);
    }
}

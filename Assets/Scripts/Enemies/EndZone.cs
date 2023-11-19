using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndZone : MonoBehaviour
{
    int objectiveHealth;
    public int objectiveMaxHealth = 20;
    public GameObject bossWall;
    public Transform wallPosition1;
    public Transform wallPosition2;
    public Transform wallPosition3;
    public float wallSpawnTime;
    public TextMeshProUGUI bossHealthText;
    public int currentRamAmount;
    public int rewardRamAmount;

    GameObject wall1;
    GameObject wall2;
    GameObject wall3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("bossWalls", 15.0f, 40.0f);
        objectiveHealth = objectiveMaxHealth;
        SetBossText();
        currentRamAmount = PlayerPrefs.GetInt("Ram");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Handles damage taken and death effects
    public void ChangeHealth(int amount)
    {
        objectiveHealth = Mathf.Clamp(objectiveHealth - amount, 0, objectiveMaxHealth);
        Debug.Log(objectiveHealth + "/" + objectiveMaxHealth);

        AudioManager.instance.PlaySFX("VirusDamaged"); // Plays sound if boss takes damage

        if (objectiveHealth <= 0)
        {
            currentRamAmount += rewardRamAmount;
            PlayerPrefs.SetInt("Ram", currentRamAmount);
            SceneManager.LoadScene("WinMenu");
        }
        SetBossText();
    }

    void bossWalls()
    {
        wall1 = Instantiate(bossWall, wallPosition1.position, wallPosition1.rotation);
        Destroy(wall1, 5);
        wall2 = Instantiate(bossWall, wallPosition2.position, wallPosition2.rotation);
        Destroy(wall2, 5);
        wall3 = Instantiate(bossWall, wallPosition3.position, wallPosition3.rotation);
        Destroy(wall3, 5);
    }

    void SetBossText()
    {
        // Update the count text with the current count.
        bossHealthText.text = "Virus: " + objectiveHealth.ToString() + "/20";
    }
}

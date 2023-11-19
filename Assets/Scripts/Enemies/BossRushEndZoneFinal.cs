using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BossRushEndZoneFinal : MonoBehaviour
{
    int objectiveHealth;
    public int objectiveMaxHealth = 20;
    public TextMeshProUGUI bossHealthText;

    // Start is called before the first frame update
    void Start()
    {
        objectiveHealth = objectiveMaxHealth;
        SetBossText();
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
            //Boss death code here
            SceneManager.LoadScene("WinMenu");
        }
        SetBossText();
    }

    public void SetBossText()
    {
        // Update the count text with the current count.
        bossHealthText.text = "Virus: " + objectiveHealth.ToString() + "/20";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    int objectiveHealth;
    public int objectiveMaxHealth = 20;
    // Start is called before the first frame update
    void Start()
    {
        objectiveHealth = objectiveMaxHealth;
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


        if (objectiveHealth > 0)
        {

        }

        if (objectiveHealth <= 0)
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}

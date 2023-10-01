using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    int wallMaxHealth = 100;
    int wallCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        wallCurrentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int amount)
    {
        wallCurrentHealth = Mathf.Clamp(wallCurrentHealth - amount, 0, wallMaxHealth);
        Debug.Log(wallCurrentHealth + "/" + wallMaxHealth);
        if (wallCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

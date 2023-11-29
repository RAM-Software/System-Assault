using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    public int wallMaxHealth = 100;
    public int wallCurrentHealth;
    public int wallGold;
    public string hubTag = "SpawnZone";


    //Audio code
    AudioSource audioSource;
    public AudioClip walldamagedClip;
    public AudioClip walldestroyedClip;

    //Disable Towers Code
    [SerializeField] Base_Tower[] baseTowers;
    [SerializeField] Area_Tower[] areaTowers;
    [SerializeField] ForwardSpawn newSpawnPoint;
    [SerializeField] ForwardSpawn oldSpawnPoint;

    //Health bar
    [SerializeField] UnitHealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        wallCurrentHealth = wallMaxHealth;

        //Audio code
        audioSource = GetComponent<AudioSource>();
        healthBar = GetComponentInChildren<UnitHealthBar>();

    }

    public void ChangeHealth(int amount)
    {
        wallCurrentHealth = Mathf.Clamp(wallCurrentHealth - amount, 0, wallMaxHealth);
        Debug.Log(wallCurrentHealth + "/" + wallMaxHealth);

        healthBar.UpdateHealthBar(wallCurrentHealth, wallMaxHealth);


        if (wallCurrentHealth > 0)
        {
            //Audio code
            //PlaySound(walldamagedClip);
            AudioManager.instance.PlaySFX("WallDamaged");
        }

        if (wallCurrentHealth <= 0)
        {
            //Audio code
            //PlaySound(walldestroyedClip);
            AudioManager.instance.PlaySFX("WallDestroyed");

            PlaceUnit.currencyCount = PlaceUnit.currencyCount + wallGold;
            Debug.Log("Gold For You");
            DestroyTower();
        }
    }

    //Audio code
    public void PlaySound(AudioClip clip)
    {
       audioSource.PlayOneShot(clip);
       //AudioManager.instance.PlaySFX("WallBreak"); // example of code for audio manager
    }
    
    public void DestroyTower()
    {
        for (int i = 0; i < baseTowers.Length; i++) //loops through towers to set corruption to false.
        {
            baseTowers[i].isCorrupted = false;
        }

        for (int i = 0; i < areaTowers.Length; i++)
        {
            areaTowers[i].isCorrupted = false;
        }

        //Forward spawn
        newSpawnPoint.isActive = true;
        oldSpawnPoint.isActive = false;
        newSpawnPoint.IsActive();
        oldSpawnPoint.IsActive();

        Destroy(gameObject);



    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    public int wallMaxHealth = 100;
    public int wallCurrentHealth;
    public int wallGold = 300;
    public string hubTag = "SpawnZone";


    //Audio code
    AudioSource audioSource;
    public AudioClip walldamagedClip;
    public AudioClip walldestroyedClip;

    //Disable Towers Code
    public GameObject[] towers;
    public bool isCorrupted;

    // Start is called before the first frame update
    void Start()
    {
        wallCurrentHealth = wallMaxHealth;
        isCorrupted = true;

        //Audio code
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeHealth(int amount)
    {
        wallCurrentHealth = Mathf.Clamp(wallCurrentHealth - amount, 0, wallMaxHealth);
        Debug.Log(wallCurrentHealth + "/" + wallMaxHealth);


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
            isCorrupted = false;
            Destroy(gameObject, 0.35f); 
        }
    }

    //Audio code
    public void PlaySound(AudioClip clip)
    {
       audioSource.PlayOneShot(clip);
       //AudioManager.instance.PlaySFX("WallBreak"); // example of code for audio manager
    } 
}

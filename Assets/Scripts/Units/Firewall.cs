using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    public int wallMaxHealth = 100;
    public int wallCurrentHealth;
    public int wallGold = 300;
    public string hubTag = "SpawnZone";

    AudioSource audioSource;
    public AudioClip walldamagedClip;
    public AudioClip walldestroyedClip;

    // Start is called before the first frame update
    void Start()
    {
        wallCurrentHealth = wallMaxHealth;

        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeHealth(int amount)
    {
        wallCurrentHealth = Mathf.Clamp(wallCurrentHealth - amount, 0, wallMaxHealth);
        Debug.Log(wallCurrentHealth + "/" + wallMaxHealth);


        if (wallCurrentHealth > 0)
        {
            PlaySound(walldamagedClip);
        }

        if (wallCurrentHealth <= 0)
        {
            PlaySound(walldestroyedClip);
            PlaceUnit.currencyCount = PlaceUnit.currencyCount + wallGold;
            Destroy(gameObject, 0.35f); 
        }
    }

    public void PlaySound(AudioClip clip)
    {
       audioSource.PlayOneShot(clip);
       //AudioManager.instance.PlaySFX("WallBreak"); // example of code for audio manager
    }
}

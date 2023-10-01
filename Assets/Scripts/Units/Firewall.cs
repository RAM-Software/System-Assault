using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    int wallMaxHealth = 100;
    int wallCurrentHealth;

    AudioSource audioSource;
    public AudioClip walldamagedClip;
    public AudioClip walldestroyedClip;

    // Start is called before the first frame update
    void Start()
    {
        wallCurrentHealth = 100;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(gameObject, 0.35f); 
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

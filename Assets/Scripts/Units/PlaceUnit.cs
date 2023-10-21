using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlaceUnit : MonoBehaviour, ITap
{
    //Spawn Setup
    public GameObject normalUnit, fastUnit, tankUnit;
    public Transform spawnPosition;
    public Transform spawnUnitPosition;
    public string activeTroop;
    
    //Currency Variables
    public static int currencyCount = 0;
    public int goldPerSecond = 1;
    public int basicPrice = 50;
    public int fastPrice = 70;
    public int tankPrice = 150;
    public int currencyStartAmount = 500;
    public TextMeshProUGUI currencyText;
    
    //Tutorialization
    public GameObject helperText;
    
    //Timer Variables
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;


    //Audio code
    AudioSource audioSource;
    public AudioClip troopsummonClip;

    void Start()
    {
        //Starts passive currency generation
        TimerOn = true;
        InvokeRepeating("currencyGain", 2.0f, 1.0f);
        currencyCount = currencyStartAmount;
        SetCurrencyText();

        //Audio code
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                //SceneManager.LoadScene("LoseMenu");
            }
        }
        activeTroop = SelectUnit.currentTroop;
    }

    public void onTapAction()
    {
        //Troop Shop code
        Debug.Log("Clicking for purchase");
        Debug.Log(currencyCount);
        helperText.SetActive(false);
        if (activeTroop == "Basic")
        {
            if (currencyCount >= basicPrice)
            {
                Instantiate(normalUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - basicPrice;
                SetCurrencyText();

                //Audio code
                //PlaySound(troopsummonClip);
                AudioManager.instance.PlaySFX("JunkTroopSummon");
            }
            else
            {
                AudioManager.instance.PlaySFX("FailSummon");
            }
        }
        if (activeTroop == "Fast")
        {
            if (currencyCount >= fastPrice)
            {
                Instantiate(fastUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - fastPrice;
                SetCurrencyText();

                //Audio code
                //PlaySound(troopsummonClip);
                AudioManager.instance.PlaySFX("MailTroopSummon");
            }
            else
            {
                AudioManager.instance.PlaySFX("FailSummon");
            }
        }
        if (activeTroop == "Tank")
        {
            if (currencyCount >= tankPrice)
            {
                Instantiate(tankUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - tankPrice;
                SetCurrencyText();

                //Audio code
                //PlaySound(troopsummonClip);
                AudioManager.instance.PlaySFX("ZipTroopSummon");
            }
            else
            {
                AudioManager.instance.PlaySFX("FailSummon");
            }
        }
    }

    //Passive Currency Gen
    void currencyGain()
    {
        currencyCount = currencyCount + goldPerSecond;
        //Debug.Log(currencyCount);
        SetCurrencyText();
    }

    //Currency UI update
    void SetCurrencyText()
    {
        // Update the count text with the current count.
        currencyText.text = "Bytes: " + currencyCount.ToString();
    }

    //Audio code
    public void PlaySound(AudioClip clip)
    {
       audioSource.PlayOneShot(clip);
    }

    //Timer Update
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
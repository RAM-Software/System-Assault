using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timerGoldManager : MonoBehaviour
{
    //Timer Variables
    public static float TimeLeft;
    public float startingTime;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;

    public AudioSource normalMusic;
    public AudioSource rushMusic;

    private bool musicTransition = false;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        TimeLeft = startingTime;
        normalMusic.enabled = true;
        rushMusic.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

                if (TimeLeft < 120 && musicTransition == false)
                {
                    rushMusic.enabled = true;
                    normalMusic.enabled = false;

                    AudioManager.instance.PlaySFX("MusicTransition"); // Plays music transition sound
                    musicTransition = true;
                }
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                SceneManager.LoadScene("LoseMenu");
            }
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timerGoldManager : MonoBehaviour
{
    //Timer Variables
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
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

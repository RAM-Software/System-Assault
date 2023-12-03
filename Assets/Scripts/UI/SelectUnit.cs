using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    public static string currentTroop;
    // Start is called before the first frame update
    void Start()
    {
        //currentTroop = "Basic";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBasicTroop()
    {
        currentTroop = "Basic";
        Debug.Log(currentTroop);
    }
    public void SetFastTroop()
    {
        currentTroop = "Fast";
        Debug.Log(currentTroop);
    }
    public void SetTankTroop()
    {
        currentTroop = "Tank";
        Debug.Log(currentTroop);
    }

    public void SetMP3Troop()
    {
        if (PlayerPrefs.GetInt("DLC") == 1)
        {
            currentTroop = "MP3";
            Debug.Log(currentTroop);
        }
        else
        {
            AudioManager.instance.PlaySFX("FailSummon");
        }
    }

}

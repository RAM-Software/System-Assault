using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnit : MonoBehaviour, ITap
{
    public GameObject normalUnit, fastUnit, tankUnit;
    public Transform spawnPosition;
    public Transform spawnUnitPosition;
    public string activeTroop;
    public static int currencyCount = 0;

    void Start()
    {
        InvokeRepeating("currencyGain", 2.0f, 1.0f);
    }
    void Update()
    {
        activeTroop = SelectUnit.currentTroop;
    }

    public void onTapAction()
    {
        Debug.Log("Clicking for purchase");
        Debug.Log(currencyCount);
        if (activeTroop == "Basic")
        {
            if (currencyCount >= 50)
            {
                Instantiate(normalUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - 50;
            }
        }
        if (activeTroop == "Fast")
        {
            if (currencyCount >= 50)
            {
                Instantiate(fastUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - 70;
            }
        }
        if (activeTroop == "Tank")
        {
            if (currencyCount >= 50)
            {
                Instantiate(tankUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - 150;
            }
        }
    }

    void currencyGain()
    {
        currencyCount = currencyCount + 1;
        Debug.Log(currencyCount);
    }
}
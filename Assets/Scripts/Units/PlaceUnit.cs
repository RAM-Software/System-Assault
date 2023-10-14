using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceUnit : MonoBehaviour, ITap
{
    public GameObject normalUnit, fastUnit, tankUnit;
    public Transform spawnPosition;
    public Transform spawnUnitPosition;
    public string activeTroop;
    public static int currencyCount = 0;
    public int goldPerSecond = 1;
    public int basicPrice = 50;
    public int fastPrice = 70;
    public int tankPrice = 150;
    public int currencyStartAmount = 500;
    public TextMeshProUGUI currencyText;

    void Start()
    {
        InvokeRepeating("currencyGain", 2.0f, 1.0f);
        currencyCount = currencyStartAmount;
        SetCurrencyText();
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
            if (currencyCount >= basicPrice)
            {
                Instantiate(normalUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - basicPrice;
                SetCurrencyText();
            }
        }
        if (activeTroop == "Fast")
        {
            if (currencyCount >= fastPrice)
            {
                Instantiate(fastUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - fastPrice;
                SetCurrencyText();
            }
        }
        if (activeTroop == "Tank")
        {
            if (currencyCount >= tankPrice)
            {
                Instantiate(tankUnit, spawnPosition.position, spawnUnitPosition.rotation);
                currencyCount = currencyCount - tankPrice;
                SetCurrencyText();
            }
        }
    }

    void currencyGain()
    {
        currencyCount = currencyCount + goldPerSecond;
        //Debug.Log(currencyCount);
        SetCurrencyText();
    }

    void SetCurrencyText()
    {
        // Update the count text with the current count.
        currencyText.text = "Bytes: " + currencyCount.ToString();
    }
}
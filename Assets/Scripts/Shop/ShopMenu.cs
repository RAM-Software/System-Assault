using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public int ram;
    public int junkUpgrades;
    public int emailUpgrades;
    public int zipUpgrades;

    //Upgrade amounts
    public static int junkUpgradeAmount;
    public static int emailUpgradeAmount;
    public static int zipUpgradeAmount;



    public TextMeshProUGUI ramText;
    public TextMeshProUGUI junkAmountText;
    public TextMeshProUGUI emailAmountText;
    public TextMeshProUGUI zipAmountText;
    // Start is called before the first frame update
    void Start()
    {
        ram = PlayerPrefs.GetInt("Ram");
        junkUpgrades = PlayerPrefs.GetInt("JunkUpgrades");
        emailUpgrades = PlayerPrefs.GetInt("EmailUpgrades");
        zipUpgrades = PlayerPrefs.GetInt("ZipUpgrades");
    }

    // Update is called once per frame
    void Update()
    {
        ramText.text = "Ram: " + ram.ToString();

        if (junkUpgrades <= 0)
        {
            junkUpgradeAmount = 10;
        }
        else
        {
            junkUpgradeAmount = 20;
        }

        if (emailUpgrades <= 0)
        {
            emailUpgradeAmount = 15;
        }
        else
        {
            emailUpgradeAmount = 25;
        }    

        if (zipUpgrades <= 0)
        {
            zipUpgradeAmount = 20;
        }
        else
        {
            zipUpgradeAmount = 45;
        }    

        junkAmountText.text = "-" + junkUpgradeAmount.ToString();
        emailAmountText.text = "-" + emailUpgradeAmount.ToString();
        zipAmountText.text = "-" + zipUpgradeAmount.ToString();

    }

    public void UpgradeJunk()
    {
        switch(junkUpgrades)
        {
            case 0:
                if (ram < junkUpgradeAmount)//not enough
                    break;
                ram -= junkUpgradeAmount;
                junkUpgrades += 1;

                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            case 1:
                if (ram < junkUpgradeAmount) //not enough
                    break;
                ram -= junkUpgradeAmount;
                junkUpgrades += 1;
                
                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            default:
                break;
        }

        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("JunkUpgrades", junkUpgrades);
    }

    public void UpgradeEmail()
    {
        switch (emailUpgrades)
        {
            case 0:
                if (ram < emailUpgradeAmount) //not enough
                    break;
                ram -= emailUpgradeAmount;
                emailUpgrades += 1;
                
                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            case 1:
                if (ram < emailUpgradeAmount) //not enough
                    break;
                ram -= emailUpgradeAmount;
                emailUpgrades += 1;
                
                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            default:
                break;
        }

        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("EmailUpgrades", emailUpgrades);
    }

    public void UpgradeZip()
    {
        switch (zipUpgrades)
        {
            case 0:
                if (ram < zipUpgradeAmount) //not enough
                    break;
                ram -= zipUpgradeAmount;
                zipUpgrades += 1;
                
                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            case 1:
                if (ram < zipUpgradeAmount) //not enough
                    break;
                ram -= zipUpgradeAmount;
                zipUpgrades += 1;
                
                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            default:
                break;
        }

        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("ZipUpgrades", zipUpgrades);
    }
}

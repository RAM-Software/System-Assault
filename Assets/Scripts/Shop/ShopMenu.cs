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
    public int mp3Upgrades;

    //Upgrade amounts
    public static int junkUpgradeAmount;
    public static int emailUpgradeAmount;
    public static int zipUpgradeAmount;
    public static int mp3UpgradeAmount;

    public bool junkShopInfoShown;
    public bool emailShopInfoShown;
    public bool zipShopInfoShown;
    public bool mp3ShopInfoShown;

    public TextMeshProUGUI ramText;
    public TextMeshProUGUI junkAmountText;
    public TextMeshProUGUI emailAmountText;
    public TextMeshProUGUI zipAmountText;
    public TextMeshProUGUI mp3AmountText;

    public GameObject junkShopInfo;
    public GameObject emailShopInfo;
    public GameObject zipShopInfo;
    public GameObject mp3ShopInfo;
    // Start is called before the first frame update
    void Start()
    {
        ram = PlayerPrefs.GetInt("Ram");

        //junkUpgrades = 0;
        //emailUpgrades = 0;
        //zipUpgrades = 0;

        //PlayerPrefs.SetInt("JunkUpgrades", junkUpgrades);
        //PlayerPrefs.SetInt("EmailUpgrades", emailUpgrades);
        //PlayerPrefs.SetInt("ZipUpgrades", zipUpgrades);

        junkUpgrades = PlayerPrefs.GetInt("JunkUpgrades");
        emailUpgrades = PlayerPrefs.GetInt("EmailUpgrades");
        zipUpgrades = PlayerPrefs.GetInt("ZipUpgrades");
        mp3Upgrades = PlayerPrefs.GetInt("MP3Upgrades");
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
            emailUpgradeAmount = 25;
        }
        else
        {
            emailUpgradeAmount = 45;
        }    

        if (zipUpgrades <= 0)
        {
            zipUpgradeAmount = 60;
        }
        else
        {
            zipUpgradeAmount = 100;
        }

        if (mp3Upgrades <= 0)
        {
            mp3UpgradeAmount = 30;
        }
        else
        {
            mp3UpgradeAmount = 40;
        }

        junkAmountText.text = "-" + junkUpgradeAmount.ToString();
        emailAmountText.text = "-" + emailUpgradeAmount.ToString();
        zipAmountText.text = "-" + zipUpgradeAmount.ToString();
        mp3AmountText.text = "-" + mp3UpgradeAmount.ToString();

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

    public void UpgradeMP3()
    {
        switch (mp3Upgrades)
        {
            case 0:
                if (ram < mp3UpgradeAmount) //not enough
                    break;
                ram -= mp3UpgradeAmount;
                mp3Upgrades += 1;

                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            case 1:
                if (ram < mp3UpgradeAmount) //not enough
                    break;
                ram -= mp3UpgradeAmount;
                mp3Upgrades += 1;

                AudioManager.instance.PlaySFX("ShopPurchase"); // Plays sound when upgrade is purchased

                break;

            default:
                break;
        }

        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("MP3Upgrades", mp3Upgrades);
    }

    public void JunkShopInfo()
    {
        if (junkShopInfoShown == false)
        {
            junkShopInfo.SetActive(true);
            junkShopInfoShown = true;
        }
        else if (junkShopInfoShown == true)
        {
            junkShopInfo.SetActive(false);
            junkShopInfoShown = false;
        }
    }
    public void EmailShopInfo()
    {
        if (emailShopInfoShown == false)
        {
            emailShopInfo.SetActive(true);
            emailShopInfoShown = true;
        }
        else if (emailShopInfoShown == true)
        {
            emailShopInfo.SetActive(false);
            emailShopInfoShown = false;
        }
    }
    public void ZipShopInfo()
    {
        if (zipShopInfoShown == false)
        {
            zipShopInfo.SetActive(true);
            zipShopInfoShown = true;
        }
        else if (zipShopInfoShown == true)
        {
            zipShopInfo.SetActive(false);
            zipShopInfoShown = false;
        }
    }

    public void MP3ShopInfo()
    {
        if (mp3ShopInfoShown == false)
        {
            mp3ShopInfo.SetActive(true);
            mp3ShopInfoShown = true;
        }
        else if (mp3ShopInfoShown == true)
        {
            mp3ShopInfo.SetActive(false);
            mp3ShopInfoShown = false;
        }
    }
}

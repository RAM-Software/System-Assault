using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public int ram;
    public int junkUpgrades;
    public int emailUpgraes;
    public int zipUpgrades;

    public TextMeshProUGUI ramText;
    // Start is called before the first frame update
    void Start()
    {
        ram = PlayerPrefs.GetInt("Ram");
        junkUpgrades = PlayerPrefs.GetInt("JunkUpgrades");
        emailUpgraes = PlayerPrefs.GetInt("EmailUpgrades");
        zipUpgrades = PlayerPrefs.GetInt("ZipUpgrades");
    }

    // Update is called once per frame
    void Update()
    {
        ramText.text = "Ram" + ram.ToString();
    }

    public void UpgradeJunk()
    {
        switch(junkUpgrades)
        {
            case 1:
                ram -= 5;
                break;

            case 2:
                ram -= 10;
                break;

            case 3:
                ram -= 20;
              break;

            default:
                break;
        }

        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("junkUpgrades", junkUpgrades);
    }

    public void UpgradeEmail()
    {
        switch (emailUpgraes)
        {
            case 1:
                ram -= 10;
                break;

            case 2:
                ram -= 15;
                break;

            case 3:
                ram -= 25;
                break;

            default:
                break;
        }
        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("EmailUpgrades", emailUpgraes);
    }

    public void UpgradeZip()
    {
        switch (zipUpgrades)
        {
            case 1:
                ram -= 15;
                break;

            case 2:
                ram -= 30;
                break;

            case 3:
                ram -= 45;
                break;

            default:
                break;
        }

        PlayerPrefs.SetInt("Ram", ram);
        PlayerPrefs.SetInt("ZipUpgrades", zipUpgrades);
    }
}

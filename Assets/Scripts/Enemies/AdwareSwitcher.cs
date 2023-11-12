using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdwareSwitcher : MonoBehaviour
{
    public GameObject AdSet1;
    public GameObject AdSet2;
    bool AdSet1Active = true;
    bool AdSet2Active = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("adSwitch", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void adSwitch()
    {
        Debug.Log("Adswitch running");
        if (AdSet1Active == false)
        {
            Debug.Log("Adswitch1");
            AdSet1.SetActive(true);
            AdSet2.SetActive(false);
            AdSet1Active = true;
            AdSet2Active = false;
        }

        else if (AdSet2Active == false)
        {
            Debug.Log("Adswitch2");
            AdSet2.SetActive(true);
            AdSet1.SetActive(false);
            AdSet2Active = true;
            AdSet1Active = false;
        }
    }
}

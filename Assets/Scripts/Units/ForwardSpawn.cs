using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpawn : MonoBehaviour
{
    public GameObject recycleBin;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsActive()
    {
        if (isActive == false)
        {
            recycleBin.SetActive(false);
        }
        else if (isActive)
        {
            recycleBin.SetActive(true);
        }
    }    
}

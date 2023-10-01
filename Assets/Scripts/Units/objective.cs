using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective : MonoBehaviour
{
    //The location units move towards.
    public static Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

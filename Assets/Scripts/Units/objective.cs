using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective : MonoBehaviour
{
    //The location units move towards.
    public Vector3 targetPosition;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject Objective3;
    public GameObject Objective4;
    public GameObject Objective5;
    public GameObject Objective6;
    public GameObject Objective7;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Objective1.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other = Objective1.GetComponent<Collider>())
        {
            targetPosition = Objective2.GetComponent<Transform>().position;
        }
        if(other = Objective2.GetComponent<Collider>())
        {
            targetPosition = Objective3.GetComponent<Transform>().position;
        }
        if(other = Objective3.GetComponent<Collider>())
        {
            targetPosition = Objective4.GetComponent<Transform>().position;
        }
        if(other = Objective4.GetComponent<Collider>())
        {
            targetPosition = Objective5.GetComponent<Transform>().position;
        }
        if(other = Objective5.GetComponent<Collider>())
        {
            targetPosition = Objective6.GetComponent<Transform>().position;
        }
        if(other = Objective6.GetComponent<Collider>())
        {
            targetPosition = Objective7.GetComponent<Transform>().position;
        }
    }
}

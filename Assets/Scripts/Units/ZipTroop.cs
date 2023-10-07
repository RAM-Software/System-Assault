using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZipTroop : MonoBehaviour
{
    //Pathing Variables
    private Vector3 targetPosition;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject Objective3;
    public GameObject Objective4;
    public GameObject Objective5;
    public GameObject Objective6;
    public GameObject Objective7;

    //Health Variables
    public int maxHealth = 50;
    int currentHealth;

    //Attack Variables
    public int attackDamage = 5;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //NavMesh Variables
    private NavMeshAgent troopAgent;

    //Death spawn Variables
    public GameObject JunkTrooper;
    GameObject clone1;
    GameObject clone2;
    GameObject clone3;

    private void Awake()
    {
        troopAgent = GetComponent<NavMeshAgent>();
        currentHealth = 100;
        targetPosition = Objective1.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        troopAgent.destination = targetPosition;
    }

    //Attack Collision
    private void OnCollisionStay(Collision other)
    {
        if (!alreadyAttacked)
        {
            //Attack code here
            Firewall wall = other.gameObject.GetComponent<Firewall>();
            if (wall != null)
            {
                troopAgent.enabled = false;
                wall.ChangeHealth(attackDamage);
                ChangeHealth(100);
            }
            //End of Attack code

            // Starts break between attacks
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    //Ends break between attacks
    private void ResetAttack()
    {
        alreadyAttacked = false;
        troopAgent.enabled = true;
    }

    //Handles damage taken and death effects
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);


        if (currentHealth > 0)
        {
            
        }

        if (currentHealth <= 0)
        {
            clone1 = Instantiate(JunkTrooper, transform.position, transform.rotation);
            clone2 = Instantiate(JunkTrooper, transform.position, transform.rotation);
            clone3 = Instantiate(JunkTrooper, transform.position, transform.rotation);
            BaseTroop cloneScript1 = clone1.GetComponent<BaseTroop>();
            cloneScript1.targetPosition = targetPosition;
            BaseTroop cloneScript2 = clone2.GetComponent<BaseTroop>();
            cloneScript2.targetPosition = targetPosition;
            BaseTroop cloneScript3 = clone3.GetComponent<BaseTroop>();
            cloneScript3.targetPosition = targetPosition;
            Destroy(gameObject);
        }
    }

    //Sets pathing points
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Objective1")
        {
            targetPosition = Objective2.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective2")
        {
            targetPosition = Objective3.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective3")
        {
            targetPosition = Objective4.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective4")
        {
            targetPosition = Objective5.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective5")
        {
            targetPosition = Objective6.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective6")
        {
            targetPosition = Objective7.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "EndZone")
        {
            Destroy(gameObject);
        }
    }
}

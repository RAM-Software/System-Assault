using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseTroop : MonoBehaviour
{
    //Health Variables
    int maxHealth = 50;
    int currentHealth;

    //Attack Variables
    public int attackDamage = 5;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //NavMesh Variables
    private NavMeshAgent troopAgent;
    
    private void Awake()
    {
        troopAgent = GetComponent<NavMeshAgent>();
        currentHealth = 50;
    }

    // Update is called once per frame
    void Update()
    {
        troopAgent.destination = objective.targetPosition; 
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
                wall.ChangeHealth(attackDamage);
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
    }
}

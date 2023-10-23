using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseTroop : MonoBehaviour
{
    //Pathing Variables
    public Vector3 targetPosition;
    GameObject Objective1;
    GameObject Objective2;
    GameObject Objective3;
    GameObject Objective4;
    GameObject Objective5;
    GameObject Objective6;
    GameObject Objective7;

    //Health Variables
    public int maxHealth = 50;
    int currentHealth;

    //Attack Variables
    public int attackDamage = 5;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int endGoalDamage;

    //NavMesh Variables
    private NavMeshAgent troopAgent;

    //Health bar
    [SerializeField] UnitHealthBar healthBar;

    private void Awake()
    {
        troopAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        Objective1 = GameObject.Find("Objective1");
        targetPosition = Objective1.GetComponent<Transform>().position;
        healthBar = GetComponentInChildren<UnitHealthBar>();
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
            EndZone end = other.gameObject.GetComponent<EndZone>();
            if (wall != null)
            {
                troopAgent.enabled = false;
                wall.ChangeHealth(attackDamage);
            }
            if (end != null)
            {
                end.ChangeHealth(endGoalDamage);
                Destroy(gameObject);
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

        healthBar.UpdateHealthBar(currentHealth, maxHealth);


        if (currentHealth > 0)
        {

        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Sets pathing points
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Objective1")
        {
            Objective2 = GameObject.Find("Objective2");
            targetPosition = Objective2.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective2")
        {
            Objective3 = GameObject.Find("Objective3");
            targetPosition = Objective3.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective3")
        {
            Objective4 = GameObject.Find("Objective4");
            targetPosition = Objective4.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective4")
        {
            Objective5 = GameObject.Find("Objective5");
            targetPosition = Objective5.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective5")
        {
            Objective6 = GameObject.Find("Objective6");
            targetPosition = Objective6.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective6")
        {
            Objective6 = GameObject.Find("EndZone");
            targetPosition = Objective6.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "EndZone")
        {
            AudioManager.instance.PlaySFX("TroopSucceed");
            Destroy(gameObject);
        }
    }
}
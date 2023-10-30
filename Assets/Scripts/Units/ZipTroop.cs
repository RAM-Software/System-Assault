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
    public int endGoalDamage;

    //NavMesh Variables
    private NavMeshAgent troopAgent;

    //Death spawn Variables
    public GameObject JunkTrooper;
    GameObject clone1;
    GameObject clone2;
    GameObject clone3;
    GameObject clone4;
    GameObject clone5;
    GameObject clone6;
    GameObject clone7;


    //Health bar
    [SerializeField] UnitHealthBar healthBar;

    //Upgrades
    public int upgradeLevel;

    private void Awake()
    {
        troopAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        Objective1 = GameObject.Find("Objective1");
        targetPosition = Objective1.GetComponent<Transform>().position;
        healthBar = GetComponentInChildren<UnitHealthBar>();
        upgradeLevel = PlayerPrefs.GetInt("ZipUpgrades");
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

        if (currentHealth <= 0)
        {
            if (upgradeLevel <= 0)
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
            }
            else if (upgradeLevel >= 1)
            {
                clone1 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone2 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone3 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone4 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone5 = Instantiate(JunkTrooper, transform.position, transform.rotation);

                BaseTroop cloneScript1 = clone1.GetComponent<BaseTroop>();
                cloneScript1.targetPosition = targetPosition;
                BaseTroop cloneScript2 = clone2.GetComponent<BaseTroop>();
                cloneScript2.targetPosition = targetPosition;
                BaseTroop cloneScript3 = clone3.GetComponent<BaseTroop>();
                cloneScript3.targetPosition = targetPosition;
                BaseTroop cloneScript4 = clone4.GetComponent<BaseTroop>();
                cloneScript4.targetPosition = targetPosition;
                BaseTroop cloneScript5 = clone5.GetComponent<BaseTroop>();
                cloneScript5.targetPosition = targetPosition;
            }
            else if (upgradeLevel >= 2)
            {
                clone1 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone2 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone3 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone4 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone5 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone6 = Instantiate(JunkTrooper, transform.position, transform.rotation);
                clone7 = Instantiate(JunkTrooper, transform.position, transform.rotation);

                BaseTroop cloneScript1 = clone1.GetComponent<BaseTroop>();
                cloneScript1.targetPosition = targetPosition;
                BaseTroop cloneScript2 = clone2.GetComponent<BaseTroop>();
                cloneScript2.targetPosition = targetPosition;
                BaseTroop cloneScript3 = clone3.GetComponent<BaseTroop>();
                cloneScript3.targetPosition = targetPosition;
                BaseTroop cloneScript4 = clone4.GetComponent<BaseTroop>();
                cloneScript4.targetPosition = targetPosition;
                BaseTroop cloneScript5 = clone5.GetComponent<BaseTroop>();
                cloneScript5.targetPosition = targetPosition;
                BaseTroop cloneScript6 = clone6.GetComponent<BaseTroop>();
                cloneScript6.targetPosition = targetPosition;
                BaseTroop cloneScript7 = clone7.GetComponent<BaseTroop>();
                cloneScript7.targetPosition = targetPosition;
            }
         
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP3Troop : MonoBehaviour
{
    //Pathing Variables
    public Vector3 targetPosition;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject Objective3;
    public GameObject Objective4;
    public GameObject Objective5;
    public GameObject Objective6;
    public GameObject Objective7;
    public GameObject Objective8;
    public GameObject Objective9;
    public GameObject Objective10;
    public GameObject Objective11;
    public GameObject Objective12;
    public GameObject Objective13;
    public GameObject Objective14;
    public GameObject Objective15;
    public GameObject Objective16;
    public GameObject Objective17;
    public GameObject Objective18;
    public GameObject Objective19;
    public GameObject Objective20;
    public GameObject Objective21;
    public GameObject Objective22;
    public GameObject Objective23;
    public GameObject Objective24;
    public GameObject Objective25;
    public GameObject Objective26;
    public GameObject Objective27;
    public GameObject Objective28;
    public GameObject Objective29;
    public GameObject Objective30;
    public GameObject Objective31;
    public GameObject Objective32;
    public GameObject Objective33;
    public GameObject Objective34;
    public GameObject Objective35;
    public GameObject Objective36;
    public GameObject Objective37;
    public GameObject Objective38;
    public GameObject Objective39;
    public GameObject Objective40;
    public GameObject Objective41;

    //Health Variables
    public int maxHealth;
    int currentHealth;

    //Attack Variables
    public int attackDamage = 5;
    public int upgradeOneAttack = 7;
    public int finalUpgradeAttack = 10;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int endGoalDamage;
    public float musicBurstInterval;
    public float explosionRadius = 4f;
    [SerializeField] private LayerMask projectileLayer;
    public ParticleSystem burstEffect;

    //NavMesh Variables
    private UnityEngine.AI.NavMeshAgent troopAgent;

    //Health bar
    [SerializeField] UnitHealthBar healthBar;

    //Upgrades
    public int upgradeLevel;

    private void Awake()
    {
        InvokeRepeating("musicBurst", musicBurstInterval, musicBurstInterval);
        Debug.Log("BurstLoopStart");
        troopAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Objective1 = GameObject.Find("Objective1");
        targetPosition = Objective1.GetComponent<Transform>().position;
        healthBar = GetComponentInChildren<UnitHealthBar>();
        upgradeLevel = PlayerPrefs.GetInt("MP3Upgrades");

        currentHealth = maxHealth;

        switch (upgradeLevel)
        {
            case 2:
                attackDamage = upgradeOneAttack;
                break;
            case 3:
                attackDamage = finalUpgradeAttack;
                break;
            default:
                break;
        }

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        troopAgent.destination = targetPosition;
    }

    void musicBurst()
    {
        Debug.Log("Burst Start");
        burstEffect.Play();

        AudioManager.instance.PlaySFX("MP3Deflect");

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, projectileLayer);
        foreach (Collider c in colliders)
        {
            Destroy(c.gameObject);
            Debug.Log("Burst Complete");
        }
    }

    //Attack Collision
    private void OnCollisionStay(Collision other)
    {
        if (!alreadyAttacked)
        {
            //Attack code here
            Firewall wall = other.gameObject.GetComponent<Firewall>();
            EndZone end = other.gameObject.GetComponent<EndZone>();
            BossRushEndZone rushend = other.gameObject.GetComponent<BossRushEndZone>();
            BossRushEndZoneFinal finalend = other.gameObject.GetComponent<BossRushEndZoneFinal>();
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
            if (rushend != null)
            {
                rushend.ChangeHealth(endGoalDamage);
                Destroy(gameObject);
            }
            if (finalend != null)
            {
                finalend.ChangeHealth(endGoalDamage);
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
            Destroy(gameObject);

            //AudioManager.instance.PlaySFX("TroopDefeated"); // Plays troop defeated sound on death
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
            Objective7 = GameObject.Find("Objective7");
            targetPosition = Objective7.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective7")
        {
            Objective8 = GameObject.Find("Objective8");
            targetPosition = Objective8.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective8")
        {
            Objective9 = GameObject.Find("Objective9");
            targetPosition = Objective9.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective9")
        {
            Objective10 = GameObject.Find("Objective10");
            targetPosition = Objective10.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective10")
        {
            Objective11 = GameObject.Find("Objective11");
            targetPosition = Objective11.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective11")
        {
            Objective12 = GameObject.Find("Objective12");
            targetPosition = Objective12.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective12")
        {
            Objective13 = GameObject.Find("Objective13");
            targetPosition = Objective13.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective13")
        {
            Objective14 = GameObject.Find("Objective14");
            targetPosition = Objective14.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective14")
        {
            Objective15 = GameObject.Find("Objective15");
            targetPosition = Objective15.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective15")
        {
            Objective16 = GameObject.Find("Objective16");
            targetPosition = Objective16.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective16")
        {
            Objective17 = GameObject.Find("Objective17");
            targetPosition = Objective17.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective17")
        {
            Objective18 = GameObject.Find("Objective18");
            targetPosition = Objective18.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective18")
        {
            Objective19 = GameObject.Find("Objective19");
            targetPosition = Objective19.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective19")
        {
            Objective20 = GameObject.Find("Objective20");
            targetPosition = Objective20.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective20")
        {
            Objective21 = GameObject.Find("Objective21");
            targetPosition = Objective21.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective21")
        {
            Objective22 = GameObject.Find("Objective22");
            targetPosition = Objective22.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective22")
        {
            Objective23 = GameObject.Find("Objective23");
            targetPosition = Objective23.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective23")
        {
            Objective24 = GameObject.Find("Objective24");
            targetPosition = Objective24.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective24")
        {
            Objective25 = GameObject.Find("Objective25");
            targetPosition = Objective25.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective25")
        {
            Objective26 = GameObject.Find("Objective26");
            targetPosition = Objective26.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective26")
        {
            Objective27 = GameObject.Find("Objective27");
            targetPosition = Objective27.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective27")
        {
            Objective28 = GameObject.Find("Objective28");
            targetPosition = Objective28.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective28")
        {
            Objective29 = GameObject.Find("Objective29");
            targetPosition = Objective29.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective29")
        {
            Objective30 = GameObject.Find("Objective30");
            targetPosition = Objective30.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective30")
        {
            Objective31 = GameObject.Find("Objective31");
            targetPosition = Objective31.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective31")
        {
            Objective32 = GameObject.Find("Objective32");
            targetPosition = Objective32.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective32")
        {
            Objective33 = GameObject.Find("Objective33");
            targetPosition = Objective33.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective33")
        {
            Objective34 = GameObject.Find("Objective34");
            targetPosition = Objective34.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective34")
        {
            Objective35 = GameObject.Find("Objective35");
            targetPosition = Objective35.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective35")
        {
            Objective36 = GameObject.Find("Objective36");
            targetPosition = Objective36.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective36")
        {
            Objective37 = GameObject.Find("Objective37");
            targetPosition = Objective37.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective37")
        {
            Objective38 = GameObject.Find("Objective38");
            targetPosition = Objective38.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective38")
        {
            Objective39 = GameObject.Find("Objective39");
            targetPosition = Objective39.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective39")
        {
            Objective40 = GameObject.Find("Objective40");
            targetPosition = Objective40.GetComponent<Transform>().position;
        }
        if (other.gameObject.name == "Objective40")
        {
            Objective41 = GameObject.Find("Objective41");
            targetPosition = Objective41.GetComponent<Transform>().position;
        }
    }
}

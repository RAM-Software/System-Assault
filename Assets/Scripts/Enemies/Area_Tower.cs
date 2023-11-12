using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Tower : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Programmer Use Only")]
    public Transform partToRotate;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public string enemyTag = "Enemy";

    //Audio code
    AudioSource audioSource;
    public AudioClip cannontowerShoot;

    //Determines if towers can fire
    public bool isCorrupted;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        //Audio code
        audioSource = GetComponent<AudioSource>();

        //Towers corrupted by default
        isCorrupted = true;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        //Backup code in case quaternion rotation is needed
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCountdown <= 0f && isCorrupted) // Can only fire if isCorrupted is false and countdown is up
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileArea projectile = projectileGO.GetComponent<projectileArea>();

        //Audio code
        PlaySound(cannontowerShoot);
        //AudioManager.instance.PlaySFX("CannonTowerShoot");

        if (projectile != null)
            projectile.Seek(target);
    }

    //View range in engine
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    //Audio code
    public void PlaySound(AudioClip clip)
    {
       audioSource.PlayOneShot(clip);
    } 
}

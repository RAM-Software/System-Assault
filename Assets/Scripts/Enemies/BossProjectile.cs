using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public int attackDamage = 10;
    public float explosionRadius = 4f;
    [SerializeField] private LayerMask enemyLayer;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //Phased out but may be needed again later
        /*if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }*/

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void OnCollisionEnter(Collision other)
    {
        //Particle code
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        CheckForEnemies();
    }

    //Area of effect explosion code
    private void CheckForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<FastTroop>())
            {
                c.GetComponent<FastTroop>().ChangeHealth(attackDamage);
            }
            if (c.GetComponent<ZipTroop>())
            {
                c.GetComponent<ZipTroop>().ChangeHealth(attackDamage);
            }
            if (c.GetComponent<BaseTroop>())
            {
                c.GetComponent<BaseTroop>().ChangeHealth(attackDamage);
            }
            if (c.GetComponent<MP3Troop>())
            {
                c.GetComponent<MP3Troop>().ChangeHealth(attackDamage);
            }
        }
        Destroy(gameObject);
    }

    //Phased out but may be needed again later
    void HitTarget()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBasic : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int attackDamage = 10;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
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
        FastTroop speedtroop = other.gameObject.GetComponent<FastTroop>();
        if (speedtroop != null)
        {
            speedtroop.ChangeHealth(attackDamage);
        }
        BaseTroop basetroop = other.gameObject.GetComponent<BaseTroop>();
        if (basetroop != null)
        {
            basetroop.ChangeHealth(attackDamage);
        }
        ZipTroop tanktroop = other.gameObject.GetComponent<ZipTroop>();
        if (tanktroop != null)
        {
            tanktroop.ChangeHealth(attackDamage);
        }
        Destroy(gameObject);
    }
    
    //Phased out but may be needed again later
    void HitTarget()
    {
        Destroy(gameObject);
    }
}

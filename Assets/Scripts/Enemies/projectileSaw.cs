using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSaw : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int attackDamage = 10;
    private int spinCount = 3;
    private bool canDamage = true;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
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
        InvokeRepeating("spinTimer", 1f, 1f);
    }

    void OnCollisionStay(Collision other)
    {
        FastTroop speedtroop = other.gameObject.GetComponent<FastTroop>();
        if (speedtroop != null)
        {
            if(canDamage == true)
            {
                speedtroop.ChangeHealth(attackDamage);
                canDamage = false;
                if (spinCount <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        BaseTroop basetroop = other.gameObject.GetComponent<BaseTroop>();
        if (basetroop != null)
        {
            if (canDamage == true)
            {
                basetroop.ChangeHealth(attackDamage);
                canDamage = false;
                if (spinCount <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        ZipTroop tanktroop = other.gameObject.GetComponent<ZipTroop>();
        if (tanktroop != null)
        {
            if (canDamage == true)
            {
                tanktroop.ChangeHealth(attackDamage);
                canDamage = false;
                if (spinCount <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        MP3Troop musictroop = other.gameObject.GetComponent<MP3Troop>();
        if (musictroop != null)
        {
            if (canDamage == true)
            {
                musictroop.ChangeHealth(attackDamage);
                canDamage = false;
                if (spinCount <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void spinTimer()
    {
        canDamage = true;
        spinCount = spinCount - 1;
    }
}

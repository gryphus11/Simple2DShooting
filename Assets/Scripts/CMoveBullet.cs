using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveBullet : CDirectionMove, IObjectConflict {

    public float damage = 0.0f;
    public float lifeTime = 0.0f;
    public GameObject laserEffect = null;
    public Animator animator = null;

    public int Conflict(CShipHealth health)
    {
        return health.HpDown(damage);
    }

    protected void OnEnable()
    {
        Invoke("DestroyObject", lifeTime);
    }

    protected void OnDisable()
    {
        CancelInvoke();
    }

    public void DestroyObject()
    {
        CObjectPool.current.PoolObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            if (laserEffect != null)
            {
                GameObject effect = Instantiate(laserEffect, transform.position, Quaternion.identity);

                Destroy(effect, 0.5f);
            }
            animator.Play("Damage", 0);
            DestroyObject();
        }
    }

    public void ManualDestroy()
    {
        GameObject effect = Instantiate(laserEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        DestroyObject();
    }
}

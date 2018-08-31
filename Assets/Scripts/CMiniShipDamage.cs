using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMiniShipDamage : CShipDamage
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Missile")
        {
            ShowHitEffect(transform.position);
            CObjectPool.current.PoolObject(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            ShowHitEffect(transform.position);
            Destroy(gameObject);
        }
    }

}

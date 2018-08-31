using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShipDamage : MonoBehaviour, IObjectConflict
{

    public Animator animator = null;
    public GameObject effectObject = null;
    public CShipHealth shipHealth = null;
    public float damage = 0.0f;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Missile")
        {
            Hit(collision);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
                return;

            player.GetComponent<CLaserTimerManager>().LaserPowerUp(0.05f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Hit(collision);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
                return;
            player.GetComponent<CLaserTimerManager>().LaserPowerUp(0.0001f);
        }
    }

    public void Hit(Collider2D collision)
    {
        IObjectConflict conflict = collision.GetComponent<IObjectConflict>();

        if (conflict == null)
            return;

        ShowHitEffect(transform.position);
        int hp = conflict.Conflict(shipHealth);

        if (hp <= 0)
        {
            shipHealth.DoDestroy();
        }

        conflict.DestroyObject();
    }

    public void ShowHitEffect(Vector2 position)
    {
        if (effectObject != null)
        {
            GameObject effect = Instantiate(effectObject, position, Quaternion.identity);

            Destroy(effect, 0.5f);
        }
        animator.Play("Damage", 0);
    }

    public int Conflict(CShipHealth health)
    {
        return health.HpDown(damage);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerShipDamage : CShipDamage {

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Damage") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("NewShip"))
            return;

        base.OnTriggerEnter2D(collision);

        if (collision.tag == "Enemy")
            Hit(collision);
    }

    private void OnEnable()
    {
        animator.Play("NewShip");
    }
}

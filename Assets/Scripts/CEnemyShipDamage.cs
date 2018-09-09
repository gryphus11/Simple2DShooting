using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyShipDamage : CShipDamage {

    public int scorePerHit = 0;
    public int laserHitRate = 2;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Missile")
        {
            Hit(collision);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
                return;

            player.GetComponent<CLaserTimerManager>().LaserPowerUp(0.05f);
            CScoreManager.AddScore(scorePerHit);
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Hit(collision);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
                return;
            player.GetComponent<CLaserTimerManager>().LaserPowerUp(0.0001f);
            CScoreManager.AddScore(scorePerHit * laserHitRate);
        }
    }
}

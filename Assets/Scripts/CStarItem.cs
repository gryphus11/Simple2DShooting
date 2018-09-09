using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CStarItem : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlayerShip")
        {
            CScoreManager.AddScore(10);

            Destroy(gameObject);
            //CObjectPool.current.PoolObject(gameObject);
        }
    }
}

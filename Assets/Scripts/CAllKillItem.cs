using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAllKillItem : MonoBehaviour {

    private GameObject[] _enemies = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < _enemies.Length; ++i)
            {
                _enemies[i].GetComponent<CShipHealth>().ManualDestroy();
            }
            Destroy(gameObject);
            //CObjectPool.current.PoolObject(gameObject);
        }
    }
}

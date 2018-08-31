using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCapsuleItem : MonoBehaviour
{
    private CPlayerShipHealth _playerHealth = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlayerShip")
        {
            if(_playerHealth != null)
                _playerHealth.HpUp(50.0f);
            Destroy(gameObject);
            //CObjectPool.current.PoolObject(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CPlayerShipHealth>();
    }
}

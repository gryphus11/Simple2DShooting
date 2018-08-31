using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLaserUpItem : MonoBehaviour {

    private CInputShot _playerShot = null;

	// Use this for initialization
	void Start () {
        _playerShot = GameObject.FindWithTag("Player").GetComponent<CInputShot>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerShot.ShotCountUp();
            Destroy(gameObject);
            //CObjectPool.current.PoolObject(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMiniShipItem : MonoBehaviour {

    public GameObject miniShipPrefab = null;
    private CMiniShipInstall _miniShipInstall = null;

    // Use this for initialization
    void Start () {
        _miniShipInstall = GameObject.FindGameObjectWithTag("Player").GetComponent<CMiniShipInstall>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _miniShipInstall.InstallMiniShip(miniShipPrefab);
            //CObjectPool.current.PoolObject(gameObject);
            Destroy(gameObject);
        }
    }
}

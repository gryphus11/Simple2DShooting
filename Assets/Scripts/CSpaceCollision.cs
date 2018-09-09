using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpaceCollision : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Laser" || collision.tag == "Player")
            return;
        else
            CObjectPool.current.PoolObject(collision.gameObject);
            //Destroy(collision.gameObject);
    }
}

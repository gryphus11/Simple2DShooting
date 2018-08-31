using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpaceCollision : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Missile" || collision.tag == "Laser" || collision.tag == "Player")
            return;
        else
            Destroy(collision.gameObject);
    }
}

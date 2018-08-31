using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerGenerator : MonoBehaviour {

    public GameObject playerShip = null;
    public Transform playerGenPosition = null;

    public void InitPlayerShip()
    {
        StartCoroutine(InitShip());
    }

    IEnumerator InitShip()
    {
        Debug.Log("재생성중");
        yield return new WaitForSeconds(1.0f);
        playerShip.transform.position = playerGenPosition.position;
        playerShip.SetActive(true);
    }
}

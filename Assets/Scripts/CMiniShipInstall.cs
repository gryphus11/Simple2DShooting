using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMiniShipInstall : MonoBehaviour {

    public Transform[] miniShipPos = null;

    public void InstallMiniShip(GameObject miniShipPrefab)
    {
        foreach (Transform shipPos in miniShipPos)
        {
            if (shipPos.childCount > 0)
                continue;

            GameObject miniShip = Instantiate(miniShipPrefab, shipPos.position, shipPos.rotation);
            miniShip.transform.SetParent(shipPos);
            break;
        }
    }
}

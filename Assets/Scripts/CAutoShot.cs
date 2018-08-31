using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAutoShot : CInputShot
{

    public void SetAutoShot(bool auto)
    {
        if(auto)
            StartCoroutine(AutoShotCoroutine());
        else
            StopCoroutine(AutoShotCoroutine());
    }

        

    IEnumerator AutoShotCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < _shotPosCount; ++i)
            {
                GameObject bullet = CObjectPool.current.GetObject(weaponPrefab);
                bullet.transform.position = shotPos[i].position;
                bullet.transform.rotation = shotPos[i].rotation;
                bullet.SetActive(true);
            }

        }
    }
}

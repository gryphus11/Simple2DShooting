using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyDelayShot : CShot
{

    public float fireDelayTime = 0.0f;
    public CDirectionMove movement = null;

    // Use this for initialization
    protected override void Start()
    {
        StartCoroutine(DelayShotCoroutine());
    }

    private IEnumerator DelayShotCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotDelay);
            movement.Stop();
            for (int i = 0; i < shotPos.Length; ++i)
            {
                yield return new WaitForSeconds(fireDelayTime);
                Fire(weaponPrefab, shotPos[i].position, shotPos[i].rotation);
            }
            movement.Resume();
        }
    }
}

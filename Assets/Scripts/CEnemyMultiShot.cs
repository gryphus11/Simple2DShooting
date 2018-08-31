using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyMultiShot : CEnemyShot
{

    public int multiShotCount = 0;

    // Use this for initialization
    protected override void Shot()
    {
        StartCoroutine(MultiShotCoroutine());
    }

    IEnumerator MultiShotCoroutine()
    {
        yield return new WaitForSeconds(shotDelay);

        for (int i = 0; i < multiShotCount; ++i)
        {
            base.Shot();
            yield return new WaitForSeconds(0.15f);
        }
    }
}

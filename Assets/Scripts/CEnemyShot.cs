using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyShot : CShot {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShotRepeat(shotDelay));
        //InvokeRepeating("Shot", _shotDelay, _shotDelay);
    }

    IEnumerator ShotRepeat(float shotDealy)
    {
        while (true)
        {
            yield return new WaitForSeconds(shotDelay);
            Shot();
        }
    }
}

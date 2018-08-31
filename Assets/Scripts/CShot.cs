using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShot : MonoBehaviour {

    public GameObject weaponPrefab = null;
    public Transform[] shotPos = null;
    public float shotDelay = 0.0f;

    protected int _shotPosCount = 1;

    // Use this for initialization
    protected virtual void Start()
    {
        _shotPosCount = shotPos.Length;
    }

    protected virtual void Shot()
    {
        for (int i = 0; i < _shotPosCount; ++i)
        {
            Fire(weaponPrefab, shotPos[i].position, shotPos[i].transform.rotation);
        }
    }

    protected void Fire(GameObject missilePrefab, Vector2 position, Quaternion rotate)
    {
        //Instantiate(missilePrefab, position, rotate);
        GameObject weapon = CObjectPool.current.GetObject(missilePrefab);
        if (weapon == null)
            return;
        weapon.transform.position = position;
        weapon.transform.rotation = rotate;
        weapon.SetActive(true);
    }
}

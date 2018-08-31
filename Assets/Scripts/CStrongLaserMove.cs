using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStrongLaserMove : MonoBehaviour, IObjectConflict
{
    public float laserDamage = 0.0f;
    public float maxWidthScale = 15.0f;

    private Transform _playerLaserPos = null;
    private Vector2 _laserPosition = Vector2.zero;
    private CLaserTimerManager _laserTimer = null;

    void Start()
    {
        _playerLaserPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _laserTimer = GameObject.FindGameObjectWithTag("Player").GetComponent<CLaserTimerManager>();
        StartCoroutine(LaserTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerLaserPos == null)
            return;

        if (_laserTimer.GetTimer() == 0.0f)
            GetComponent<Animator>().SetTrigger("LaserOff");

        _laserPosition = _playerLaserPos.position;
        _laserPosition.y = _playerLaserPos.position.y + 5.7f;

         transform.position = _laserPosition;
    }

    public void DestroyLaser()
    {
        StopCoroutine(LaserTimer());
        Debug.Log("레이저 파괴");
        Destroy(gameObject);
    }

    public void OnDestroy()
    {

    }


    public int Conflict(CShipHealth health)
    {
        return health.HpDown(laserDamage);
    }

    public void DestroyObject()
    {
    }

    IEnumerator LaserTimer()
    {
        while (_laserTimer.GetTimer() > 0.0f)
        {
            _laserTimer.LaserPowerDown(Time.deltaTime);
            yield return null;
        }
    }

}

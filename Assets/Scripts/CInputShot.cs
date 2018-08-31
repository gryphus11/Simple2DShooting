using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputShot : CShot
{

    private float _generateTimer = 0.0f;
    public bool laserShot = false;
    public GameObject laser = null;
    private GameObject _activatedLaser = null;
    private CLaserTimerManager _laserTimer = null;

    // Use this for initialization
    protected override void Start()
    {
        _shotPosCount = 2;
        _laserTimer = GetComponent<CLaserTimerManager>();
    }

    private void OnDisable()
    {
        if (_activatedLaser != null)
            _activatedLaser.GetComponent<Animator>().SetTrigger("LaserOff");
    }

    // Update is called once per frame
    protected void Update()
    {
        _generateTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_activatedLaser == null && _laserTimer.GetTimer() > 0.0f)
                _activatedLaser = Instantiate(laser, transform.position + (Vector3.up * 5.0f), Quaternion.identity);
            else if(_activatedLaser != null)
                _activatedLaser.GetComponent<Animator>().SetTrigger("LaserOff");
        }



        if (Input.GetKey(KeyCode.Space) && _generateTimer > shotDelay && _activatedLaser == null)
        {
            _generateTimer = 0.0f;
            Shot();
        }
    }

    public void ShotCountUp()
    {

        if (_shotPosCount >= shotPos.Length)
        {
            _shotPosCount = shotPos.Length;
            return;
        }
        _shotPosCount += 2;


    }

}

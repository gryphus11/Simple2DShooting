using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLaserTimerManager : MonoBehaviour
{
    public Text laserPowerText = null;
    public Image laserProgressBar = null;
    
    private float _timerValue = 0.0f;
    public float maximumTimerValue = 10.0f;

    void Start()
    {
        laserPowerText.text = _timerValue.ToString();
    }

    private void Update()
    {
        //if (_timerValue <= 0.0f)
        //    _timerValue = 0.0f;
    }


    public float GetTimer()
    {
        return _timerValue;
    }

    public void LaserPowerUp(float powerValue)
    {
        _timerValue += powerValue;

        if (_timerValue >= maximumTimerValue)
            _timerValue = maximumTimerValue;

        laserPowerText.text = _timerValue.ToString();
        laserProgressBar.fillAmount = _timerValue / maximumTimerValue;
    }

    public void LaserPowerDown(float powerValue)
    {
        _timerValue -= powerValue;

        if (_timerValue <= 0.0f)
            _timerValue = 0.0f;

        laserPowerText.text = _timerValue.ToString();
        laserProgressBar.fillAmount = _timerValue / maximumTimerValue;
    }
}

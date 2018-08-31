using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerLifeManager : MonoBehaviour {

    public Image playerLifeImage = null;
    public Sprite[] playerLifeCount = null;

    private int _currentLifeCount = 3;
    private int _maxLifeCount = 9;
    private CGameManager _gameManager = null;

    // Use this for initialization
	void Start () {
        _gameManager = GetComponent<CGameManager>();
        SetLifeImage();
    }

    public void LifeDown()
    {
        if (_currentLifeCount == 0)
        {
            _gameManager.EndGame();
            return;
        }

        --_currentLifeCount;
        SetLifeImage();
    }

    public void LifeUp()
    {
        if (_currentLifeCount == _maxLifeCount)
            return;

        ++_currentLifeCount;
        SetLifeImage();
    }

    private void SetLifeImage()
    {
        playerLifeImage.sprite = playerLifeCount[_currentLifeCount];
    }
}

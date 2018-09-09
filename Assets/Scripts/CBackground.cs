using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBackground : MonoBehaviour {

    private static CBackground _currentBackground = null;

    private void Awake()
    {
        if (_currentBackground == null)
        {
            _currentBackground = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Screen.SetResolution(405, 720, false);
        DontDestroyOnLoad(gameObject);
	}

    private void OnDestroy()
    {
        if (_currentBackground != null)
        {
            _currentBackground = null;
            Destroy(gameObject);
        }
    }
}

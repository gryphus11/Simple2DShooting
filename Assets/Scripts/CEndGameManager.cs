using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEndGameManager : MonoBehaviour
{
    public Text bestScore = null;
    public Text yourScore = null;
    // Use this for initialization
    void Start()
    {
        int best = PlayerPrefs.GetInt("BESTSCORE", 0);
        int your = PlayerPrefs.GetInt("YOURSCORE", 0);
        bestScore.text = best.ToString();
        yourScore.text = your.ToString();
        PlayerPrefs.SetInt("YOURSCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

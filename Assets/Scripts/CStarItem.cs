using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CStarItem : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlayerShip")
        {
            GameObject starCount = GameObject.Find("StarScoreText");
            Text countText = starCount.GetComponent<Text>();

            int count = int.Parse(countText.text);
            count += 10;
            countText.text = count.ToString();

            PlayerPrefs.SetInt("YOURSCORE", count);

            int bestScore = PlayerPrefs.GetInt("BESTSCORE", 0);

            if (bestScore < count)
                PlayerPrefs.SetInt("BESTSCORE", count);

            PlayerPrefs.Save();

            Destroy(gameObject);
            //CObjectPool.current.PoolObject(gameObject);
        }
    }
}

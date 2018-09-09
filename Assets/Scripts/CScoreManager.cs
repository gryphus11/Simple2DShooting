using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CScoreManager : MonoBehaviour {

    private static CScoreManager _current = null;

    [SerializeField]
    private Text _scoreText = null;

    private void Awake()
    {
        if (_current == null)
        {
            _current = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public static void AddScore(int score)
    {
        if (_current != null)
        {
            _current.ChangeScore(score);
        }
    }

    private void ChangeScore(int score)
    {
        if (_scoreText == null)
        {
            Debug.Log("대상 텍스트가 존재하지 않습니다.");
            return;
        }

        int count = int.Parse(_scoreText.text);
        count += score;
        _scoreText.text = count.ToString();

        PlayerPrefs.SetInt("YOURSCORE", count);

        int bestScore = PlayerPrefs.GetInt("BESTSCORE", 0);

        if (bestScore < count)
            PlayerPrefs.SetInt("BESTSCORE", count);

        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        if (_current != null)
        {
            Debug.Log("점수 관리자 제거");
            _current = null;
            Destroy(gameObject);
        }
    }
}

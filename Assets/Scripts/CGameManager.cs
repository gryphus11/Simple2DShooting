using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CGameManager : MonoBehaviour {

    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }
}

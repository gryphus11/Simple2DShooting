using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneSwitcher : MonoBehaviour {

    public static void ChangeSceneByScenePath(string scenePath)
    {
        int buildIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);
        if (buildIndex == -1)
        {
            Debug.Log("유효하지 않은 Scene");
        }
        else
        {
            SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
        }
    }

}

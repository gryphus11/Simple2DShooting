using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneChangeButton : MonoBehaviour {

    public string scenePath = string.Empty;

    public void OnChangeSceneButtonClick()
    {
        CSceneSwitcher.ChangeSceneByScenePath(scenePath);
    }

    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

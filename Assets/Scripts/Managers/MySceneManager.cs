using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    [SerializeField] private Array[] _scenes;
    private bool _isChanging;
    private int _currentSceneIndex;
    public void ChangeScene(int index)
    {
        if (_isChanging) return;


    }

    public void ChangeNextScene()
    {
        if (_isChanging) return;

        StartCoroutine(LoadScene(5));
    }
    private IEnumerator LoadScene(int index)
    {
        _isChanging = true;
        //Loading Screen

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("");

        while (!asyncLoad.isDone)
        {

            yield return null;
        }
        _isChanging = false;
    }
}

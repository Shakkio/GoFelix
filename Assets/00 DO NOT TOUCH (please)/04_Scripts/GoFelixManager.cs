using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoFelixManager : PersistentSingleton<GoFelixManager>
{
    public int Lives = 3;
    public bool win = false;
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        win = false;

        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            Debug.Log("queued next game");
            Invoke("NextGame", 7.25f);
        }
    }

    public void NextGame()
    {
        if (win == false) Lives--;
        
        SceneManager.LoadScene(1);
    }

    public void NextGameFree()
    {
        SceneManager.LoadScene(1);
    }
}

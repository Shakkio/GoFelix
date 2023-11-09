using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFelixManager : PersistentSingleton<GoFelixManager>
{
    public void Win()
    {
        // Load the transition scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Lose()
    {
        // Load the transition scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}

using UnityEngine;
using FMODUnity;

public class TransitionManager : MonoBehaviour
{
    public void LoadNextGame()
    {
        // Pick a random game
        // Scene Index > 1 because 0 is the main menu and 1 is the transition scene
        int sceneIndex = Random.Range(2, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings);

        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
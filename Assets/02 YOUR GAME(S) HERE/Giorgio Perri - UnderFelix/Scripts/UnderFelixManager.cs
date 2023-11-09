using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderFelixManager : Singleton<UnderFelixManager>
{
    public GameObject DialogueBox;
    public bool Win = true;
    
    void Start()
    {
        Invoke("EnableDialogue", 0.25f);
        Invoke("StartGame", 2.25f);
        Invoke("EndGame", 7.25f);
    }

    void EnableDialogue()
    {
        DialogueBox.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
    
    void StartGame()
    {
        DialogueBox.SetActive(false);
        ObjectSpawner.Instance.StartSpawning();
    }

    void EndGame()
    {
        if (Win)
        {
            GoFelixManager.Instance.Win();
        }
        else
        {
            GoFelixManager.Instance.Lose();
        }
    }
}

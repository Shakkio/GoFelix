using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderFelixManager : Singleton<UnderFelixManager>
{
    public GameObject DialogueBox;
    
    void Start()
    {
        Invoke("EnableDialogue", 0.25f);
        Invoke("StartGame", 2.25f);
    }

    void EnableDialogue()
    {
        DialogueBox.SetActive(true);
        GetComponent<AudioSource>().Play();
        GoFelixManager.Instance.win = true;
    }
    
    void StartGame()
    {
        DialogueBox.SetActive(false);
        ObjectSpawner.Instance.StartSpawning();
    }
}

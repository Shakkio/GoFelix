using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHole : MonoBehaviour
{
    private void Start()
    {
        GoFelixManager.Instance.win = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("You win!");
            GoFelixManager.Instance.win = true;
        }
    }
}

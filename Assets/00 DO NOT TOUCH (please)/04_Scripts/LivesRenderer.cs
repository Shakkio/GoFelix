using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesRenderer : MonoBehaviour
{
    public GameObject lifePrefab;
    void Start()
    {
        //destroy all children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        //create new children
        for (int i = 0; i < GoFelixManager.Instance.Lives; i++)
        {
            Instantiate(lifePrefab, transform);
        }
        
    }
}

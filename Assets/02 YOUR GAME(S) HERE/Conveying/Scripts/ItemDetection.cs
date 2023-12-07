using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour
{
    public List<GameObject> possibleHeldItem;

    private void Awake()
    {
        possibleHeldItem = new List<GameObject>();
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(possibleHeldItem.Count);
        }
    }

}

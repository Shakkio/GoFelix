using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Singleton<ObjectSpawner>
{
    public GameObject Piss;
    public GameObject Syringe;
    
    public void StartSpawning()
    {
        InvokeRepeating("Spawn", 0, .9f);
    }
    
    void Spawn()
    {
        int random = Random.Range(0, 2);
        
        Instantiate(random == 0 ? Piss : Syringe, new Vector3(Random.Range(-1, 2), -0.5f, 0), Quaternion.identity,
            transform);
    }

    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }
}

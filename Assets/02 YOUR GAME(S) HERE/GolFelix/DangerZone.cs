using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public Collider sphere;
    
    public AudioSource source;

    public float magnitudeTrigger;

    bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponent<Rigidbody>().velocity.magnitude);
        
        if( !hasPlayed && other.GetComponent<Rigidbody>().velocity.magnitude <= magnitudeTrigger){
            source.Play();
            hasPlayed = true;
        }
    }
}

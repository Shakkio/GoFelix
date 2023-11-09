using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectDrop : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2.5f);
        Invoke("Die", 3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Heart")
        {
            Debug.Log("Died");

            foreach (Rigidbody2D rb in FindObjectsOfType(typeof(Rigidbody2D)))
            {
                rb.bodyType = RigidbodyType2D.Static;

                if (rb.gameObject.name == "Heart") continue;
                
                Destroy(rb.gameObject);
            }
            
            //stop all AudioSources
            foreach (AudioSource audioSource in FindObjectsOfType(typeof(AudioSource)))
            {
                audioSource.Stop();
            }

            ObjectSpawner.Instance.StopSpawning();
            
            col.gameObject.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<HeartController>().BreakSprite();
            UnderFelixManager.Instance.Win = false;
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}

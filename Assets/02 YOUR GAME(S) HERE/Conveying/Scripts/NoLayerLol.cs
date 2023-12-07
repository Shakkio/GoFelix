using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLayerLol : MonoBehaviour
{
    public Vector2 Direction;
    public float force;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent != null)
        if(collision.transform.parent.name == "Hand")
        {
                collision.transform.parent.GetComponent<Hand>().Push(Direction, force);
        }
    }
}

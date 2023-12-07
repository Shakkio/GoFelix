using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDetection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hand")
        {
            collision.GetComponent<ItemDetection>().possibleHeldItem.Add(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hand")
        {
            if (collision.GetComponent<ItemDetection>().possibleHeldItem.Contains(this.gameObject))
                collision.GetComponent<ItemDetection>().possibleHeldItem.Remove(this.gameObject);
        }
    }
}

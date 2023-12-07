using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THESCRIPT : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ElementDetection>())
        {
            collision.transform.parent.gameObject.AddComponent<Conveyable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ElementDetection>())
        {
            Destroy(collision.transform.parent.gameObject.GetComponent<Conveyable>());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementHolding : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject Holder;
    Vector3 displacement;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Holder != null)
        {
            KeepStill();
            KeepClose();
        }
    }

    void KeepStill()
    {
        rigidbody.velocity = new Vector3(0, 0, 0);
    }

    void KeepClose()
    {
        transform.position = Holder.transform.position + displacement;
    }

    public void SetHolder(GameObject holder)
    {
        Holder = holder;
        displacement = transform.position - Holder.transform.position;
    }
}

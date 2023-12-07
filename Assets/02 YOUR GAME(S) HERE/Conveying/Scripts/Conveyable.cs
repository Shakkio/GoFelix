using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyable : MonoBehaviour
{
    float speed = 5;
    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

}

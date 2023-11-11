using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisions : MonoBehaviour
{
    void OnCollisionEnter(){
        DOOM.Instance.Die();
    }
}

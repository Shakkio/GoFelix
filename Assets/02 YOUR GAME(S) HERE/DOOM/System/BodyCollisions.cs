using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DOOMSpace
{
    public class BodyCollisions : MonoBehaviour
    {
        void OnCollisionEnter()
        {
            DOOM.Instance.Die();
        }
    }
}

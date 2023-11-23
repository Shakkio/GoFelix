using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolFelix
{
    public class ADRotate : MonoBehaviour
    {
        //rotate the object right if d is pressed
        //rotate the object left if a is pressed
        
        public float speed = 10f;
        public float maxAngle = 30f;
        public float minAngle = -30f;
        public float angle = 0f;
        public float angleChange = 1f;
        
        public bool didShoot;

        private void Start()
        {
            // set the initial rotation of the object to a random angle between minAngle and maxAngle
            angle = UnityEngine.Random.Range(minAngle, maxAngle);
        }

        private void Update()
        {
            if (didShoot) return;
            
            if (Input.GetKey(KeyCode.D))
            {
                angle += angleChange;
                if (angle > maxAngle)
                {
                    angle = maxAngle;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                angle -= angleChange;
                if (angle < minAngle)
                {
                    angle = minAngle;
                }
            }
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

}

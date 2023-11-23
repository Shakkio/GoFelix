using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolFelix
{
    public class ESpaceShoot : MonoBehaviour
    {
        //shoot the ball object if space or E is pressed
        
        public GameObject ball;
        public GameObject arrowObject;
        
        public float strength;
    
        private WSAdjustStrength _wsAdjustStrength;

        private void Start()
        {
            _wsAdjustStrength = GetComponent<WSAdjustStrength>();
        }

        private void Update()
        {
            strength = _wsAdjustStrength.strength;
            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
            {
                _wsAdjustStrength.didShoot = true;
                arrowObject.SetActive(false);
                StartCoroutine(ShootBall());
            }
        }

        private IEnumerator ShootBall()
        {
            //wait until _wsAdjustStrength.lerpComplete is true
            
            while (!_wsAdjustStrength.lerpComplete)
            {
                yield return null;
            }
            
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * (strength * 10f));
        }
    }
}

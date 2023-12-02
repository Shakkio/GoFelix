using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace GolFelix
{
    public class ESpaceShoot : MonoBehaviour
    {
        //shoot the ball object if space or E is pressed
        
        public GameObject ball;
        public GameObject arrowObject;
        
        public float strength;
    
        private WSAdjustStrength _wsAdjustStrength;
        private ADRotate _adRotate;

        private bool canshoot = true;

        public VisualEffect ballVFX;
        public AudioSource hitSFX;
        
        private void Start()
        {
            _wsAdjustStrength = GetComponent<WSAdjustStrength>();
            _adRotate = GetComponent<ADRotate>();
        }

        private void Update()
        {
            strength = _wsAdjustStrength.strength;
            
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) && canshoot)
            {
                _wsAdjustStrength.didShoot = true;
                _adRotate.didShoot = true;
                arrowObject.SetActive(false);
                StartCoroutine(ShootBall());
                canshoot = false;
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
            ballVFX.Play();
            hitSFX.Play();
        }
    }
}

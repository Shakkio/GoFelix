using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolFelix
{
    public class WSAdjustStrength : MonoBehaviour
    {
        //adjust the strength of the swing
        //increase the strength if w is pressed
        //decrease the strength if s is pressed
        
        public float strength = 30f;
        public float maxStrength = 100f;
        public float minStrength = 30f;
        public float strengthChange = 1f;

        public bool didShoot;
        public bool lerpComplete;
        
        //additionally, adjust the scale of an object on the z axis
        //based on the strength of the swing, ranging from 0.5 to 1.5
        
        public GameObject scaleObject;
        
        //additionally, adjust the rotation of an object on the x axis only
        //based on the strength of the swing, ranging from 0 to 90
        
        public GameObject rotateObject;

        private void Update()
        {
            if (didShoot)
            { 
                //quickly lerp linearly the rotation of the rotateObject back to 0
                
                rotateObject.transform.localRotation = Quaternion.Lerp(rotateObject.transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * 50f);
                
                //if lerping is done, set lerpComplete to true with a little bit of margin
                
                if (Quaternion.Angle(rotateObject.transform.localRotation, Quaternion.Euler(0f, 0f, 0f)) < 0.1f)
                {
                    lerpComplete = true;
                }
                
                return;
            }

            if (Input.GetKey(KeyCode.W))
            {
                strength += strengthChange;
                if (strength > maxStrength)
                {
                    strength = maxStrength;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                strength -= strengthChange;
                if (strength < minStrength)
                {
                    strength = minStrength;
                }
            }
            
            scaleObject.transform.localScale = new Vector3(1f, 1f, 0.5f + strength / 100f);
            rotateObject.transform.localRotation = Quaternion.Euler(70f * (strength / 100f), 0f, 0f);
        }
    }

}

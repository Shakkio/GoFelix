using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Underfelix
{
    public class RaveColors : MonoBehaviour
    {
        private Image _image;

        void Start()
        {
            _image = GetComponent<Image>();
            InvokeRepeating("ChangeColor", 0, .1f);
        }

        void ChangeColor()
        {
            _image.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
    }
}
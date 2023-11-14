using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Underfelix
{
    public class HeartController : MonoBehaviour
    {
        private Rigidbody2D _rb; 
        private float _speed = 3f;
        
        private float _horizontal;
        private float _vertical;
        
        private float _diagonalMultiplier = 0.7f;
        
        [SerializeField] private Sprite _brokenSprite;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void BreakSprite()
        {
            GetComponent<Image>().sprite = _brokenSprite;
        }

        void Update()
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");
            
            if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
            {
                _rb.velocity = new Vector2(0f, 0f);
            }
        }
        
        void FixedUpdate()
        {
            if (_horizontal != 0 && _vertical != 0) 
            {
                _horizontal *= _diagonalMultiplier;
                _vertical *= _diagonalMultiplier;
            }

            _rb.velocity = new Vector2(_horizontal * _speed, _vertical * _speed);

            if (_horizontal == 0 && _vertical == 0)
            {
                _rb.velocity = Vector2.zero;
            }
        }
    }
}

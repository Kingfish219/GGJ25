using System;
using UnityEngine;

namespace Mohammad.Code
{
    public class PictureHandler : MonoBehaviour
    {
        private int _clickCount = 4;
        private Animator _animator;
        private static readonly int Tap = Animator.StringToHash("Tapped");
        private static readonly int Fall = Animator.StringToHash("Fall");

        void Start()
        {
            // Get the Animator component attached to the GameObject
            _animator = GetComponent<Animator>();
        }
        
        public void OnMouseDown()
        {
            if(_clickCount > 0)
            {
                _clickCount--;
                
                _animator.SetTrigger(Tap);
                
                return;
            }

            _animator.SetTrigger(Fall);
            Destroy(gameObject, 1f);
        }
    }
}
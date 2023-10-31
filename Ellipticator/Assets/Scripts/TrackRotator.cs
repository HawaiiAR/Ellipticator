using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tracks
{
    public class TrackRotator : TrackMover
    {
        public bool isVertical;

        [SerializeField] private GameObject _rotateControl;
        [SerializeField] private float _angle;
        [SerializeField] private string _direction;
        Quaternion _startRotation;
        float endRot;
        
        bool canRotate;
        bool curveStart;
        // Start is called before the first frame update
       
        
        protected override void Start()
        {
            base.Start();
            canRotate = false;
            _startRotation = _rotateControl.transform.rotation;
            curveStart = true;
        }

        // Update is called once per frame
       protected override void Update()
        {
            if (!canRotate)
            {
                base.Update();
            }
            if (canRotate)
            {
                _speed = _paceSetter.globalSpeed;

                if (isVertical)
                {
                    _rotateControl.transform.Rotate( -_speed * 10 * Time.deltaTime, 0, 0);
                    endRot = _rotateControl.transform.localEulerAngles.x;
                }
                if (!isVertical)
                {
                    _rotateControl.transform.Rotate(0, 0, -_speed * 15 * Time.deltaTime);
                    endRot = _rotateControl.transform.localEulerAngles.z;
                }
              
              //  Debug.Log(endRot);
              
                if(endRot <= _angle)
                {
                    canMove = true;
                    _moveControl.PickNextTrack();
                    curveStart = false;
                    canRotate = false;
                }
            }

        }

        private void Reset()
        {
            curveStart = true;
            _rotateControl.transform.rotation = _startRotation;
            this.gameObject.SetActive(false)
;        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MidPoint"))
            {
                if (curveStart)
                {
                    canMove = false;
                    canRotate = true;
                   
                }
                if (!curveStart)
                {
                    Reset();
                }

            }
          
        }
    }
}

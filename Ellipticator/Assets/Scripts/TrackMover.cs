using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracks
{
    public class TrackMover : MonoBehaviour
    {

      
      

        [SerializeField] protected PaceSetter _paceSetter;

        [SerializeField] protected Transform _startPoint;
        [SerializeField] protected TrackMoverControl _moveControl;

        protected float _speed;
     

        protected bool canMove;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            _paceSetter = FindObjectOfType<PaceSetter>();
            this.transform.position = _startPoint.transform.position;
        }

        protected virtual void OnEnable()
        {
            canMove = true;
            this.transform.position = _startPoint.transform.position;

        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (canMove)
            {
                _speed = _paceSetter.globalSpeed;
                transform.Translate(0, _speed * Time.deltaTime, 0);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MidPoint"))
            {
                Debug.Log("HitMidpoint");
                _moveControl.PickNextTrack();
            }
            if (other.CompareTag("EndPoint"))
            {
                Debug.Log("end");
                this.transform.position = _startPoint.transform.position;
                this.gameObject.SetActive(false);
            }
        }
    }
}

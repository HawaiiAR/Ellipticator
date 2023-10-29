using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracks
{
    public class TrackMover : MonoBehaviour
    {

      
        public float speed;

        [SerializeField] protected Transform _startPoint;
        [SerializeField] protected TrackMoverControl _moveControl;
     

        protected bool canMove;
        // Start is called before the first frame update
        protected virtual void Start()
        {
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
                transform.Translate(0, speed * Time.deltaTime, 0);
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

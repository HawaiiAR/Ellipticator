using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracks
{
    public class PaceSetter : MonoBehaviour
    {
   
        public float globalSpeed;
        [SerializeField] private float _speedMultiplier;


        void Update()
        {
            StartCoroutine(CalculateSpeed());
              
        }

        IEnumerator CalculateSpeed()
        {
            Vector3 lastPosition = this.transform.position;
            yield return new WaitForFixedUpdate();
            float localSpeed = (lastPosition - this.transform.position).magnitude / Time.deltaTime;
            globalSpeed = localSpeed * _speedMultiplier;
        }
    }
}

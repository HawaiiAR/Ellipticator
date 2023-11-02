using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracks
{
    public class PaceSetter : MonoBehaviour
    {
   
        public float globalSpeed;
        [SerializeField] private float _speedMultiplier;

        bool gameStarted;

        private void Start()
        {
            GameControl.GameStarted += StartTrackingMovement;
            gameStarted = false;
            globalSpeed = 0;
        }

        private void OnDisable()
        {
            GameControl.GameStarted -= StartTrackingMovement;
        }

        private void StartTrackingMovement()
        {
            gameStarted = true;
            globalSpeed = .01f;
        }

        void Update()
        {
            if (gameStarted)
            {
                StartCoroutine(CalculateSpeed());
            }
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

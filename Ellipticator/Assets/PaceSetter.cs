using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracks
{
    public class PaceSetter : MonoBehaviour
    {
    

      //  [SerializeField] private GameObject _paceSetter;
        public float globalSpeed;
     


        // Update is called once per frame
        void Update()
        {
            StartCoroutine(CalculateSpeed());
              
        }

        IEnumerator CalculateSpeed()
        {
            Vector3 lastPosition = this.transform.position;
            yield return new WaitForFixedUpdate();
            globalSpeed = (lastPosition - this.transform.position).magnitude / Time.deltaTime;
            Debug.Log("Speed" + globalSpeed);
        }
    }
}

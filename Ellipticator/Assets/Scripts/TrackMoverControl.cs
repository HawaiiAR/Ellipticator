using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Meta.WitAi;
using Meta.WitAi.Json;

namespace Tracks
{
    public class TrackMoverControl : MonoBehaviour
    {

        public float globalSpeed;

        [SerializeField] private List<GameObject> _availableTracks = new List<GameObject>();

        int newTrack;

        // Start is called before the first frame update
        void Start()
        {
            SetTracksState(false);
            _availableTracks[0].SetActive(true);
          
        }

     

        public void PickNextTrack()
        {
            newTrack = (newTrack + UnityEngine.Random.Range(1, _availableTracks.Count - 1)) % _availableTracks.Count;
            _availableTracks[newTrack].SetActive(true);
     
        }

        //this gets the information from wit and passes it in
        public void NextTrack(string direction)
        {
            switch (direction)
            {
                case "streight":
                    _availableTracks[0].SetActive(true);
                    Debug.Log("go streight");
                    break;

                case "right":
                    _availableTracks[2].SetActive(true);
                    Debug.Log("go righy");
                    break;
                case "left":
                    _availableTracks[3].SetActive(true);
                    Debug.Log("go left");
                    break;
                case "up":
                    _availableTracks[4].SetActive(true);
                    Debug.Log("go up");
                    break;
                case "down":
                    _availableTracks[5].SetActive(true);
                    Debug.Log("go down");
                    break;
            }
        }
    

    private void SetTracksState(bool state)
        {
        foreach(GameObject t in _availableTracks)
        {
            t.SetActive(state);
        }


          /*  foreach (GameObject t in _streightTracks)
            {
                t.SetActive(state);
            }

            foreach (GameObject c in _curveTracks)
            {
                c.SetActive(state);
            }*/
        }
    }
}


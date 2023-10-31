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

        public delegate void TurnRightGateOff(string direction);
        public static event TurnRightGateOff RightGateOff;

        public delegate void TurnLeftGateOff(string direction);
        public static event TurnLeftGateOff LeftGateOff;

        public delegate void TurnUpGateOff(string direction);
        public static event TurnUpGateOff UpGateOff;

        public delegate void TrunDownGateOff(string direction);
        public static event TrunDownGateOff DownGateOff;

        public float globalSpeed;

        [SerializeField] private List<GameObject> _availableTracks = new List<GameObject>();
        [SerializeField] private GameObject[] _arrowImages;

        int newTrack;

        bool rightTurn;
        bool leftTurn;
        bool upTurn;
        bool downTurn;

        private void Awake()
        {
            SetTracksState(false);
            _availableTracks[0].SetActive(true);
            ActivateArrowImages(false);
        }
        // Start is called before the first frame update
        void Start()
        {
           
        }

        public void PickNextTrack()
        {
            Debug.Log("TrackPicked");
            newTrack = (newTrack + UnityEngine.Random.Range(1, _availableTracks.Count - 1)) % _availableTracks.Count;
            _availableTracks[newTrack].SetActive(true);
            int arrowNum = newTrack;
            SetArrow(arrowNum);


        }

        private void SetArrow(int arrowNum)
        {
            ActivateArrowImages(false);

            switch (arrowNum)
            {
                case 0:
                    ActivateArrowImages(false);
                    break;
                case 1:
                    ActivateArrowImages(false);
                    break;
                case 2:
                    _arrowImages[0].SetActive(true);
                    rightTurn = true;
                    break;
                case 3:
                    _arrowImages[1].SetActive(true);
                    leftTurn = true;
                    break;
                case 4:
                    _arrowImages[2].SetActive(true);
                    upTurn = true;
                    break;
                case 5:
                    _arrowImages[3].SetActive(true);
                    downTurn = true;
                    break;
            }
        }

        //this gets the information from wit and passes it in
        public void NextTrack(string direction)
        {
            switch (direction)
            {
                case "streight":
                //    _availableTracks[0].SetActive(true);
                    Debug.Log("go streight");
                    break;

                case "right":
                    //     _availableTracks[2].SetActive(true);
                    RightGateOff("right");
                    _arrowImages[0].SetActive(false);
                    Debug.Log("go right");
                    break;
                case "left":
                    //     _availableTracks[3].SetActive(true);
                    LeftGateOff("left");
                    _arrowImages[1].SetActive(false);
                    Debug.Log("go left");
                    break;
                case "up":
                    //   _availableTracks[4].SetActive(true);
                    UpGateOff("up");
                    _arrowImages[2].SetActive(false);
                    Debug.Log("go up");
                    break;
                case "down":
                    //   _availableTracks[5].SetActive(true);
                    DownGateOff("down");
                    _arrowImages[3].SetActive(false);
                    Debug.Log("go down");
                    break;
            }
        }
    

        private void ActivateArrowImages(bool state)
        {
            foreach(GameObject a in _arrowImages)
            {
                a.SetActive(state);
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tracks
{
    public class WallDeactivator : MonoBehaviour
    {
        public bool isRightGate;
        public bool isLeftGate;
        public bool isUpGate;
        public bool isDownGate;

        [SerializeField] private GameObject _gate;

        void OnEnable()
        {
            TrackMoverControl.RightGateOff += TurnGateOff;
            TrackMoverControl.LeftGateOff += TurnGateOff;
            TrackMoverControl.UpGateOff += TurnGateOff;
            TrackMoverControl.DownGateOff += TurnGateOff;
        }

        private void OnDisable()
        {
            TrackMoverControl.RightGateOff -= TurnGateOff;
            TrackMoverControl.LeftGateOff -= TurnGateOff;
            TrackMoverControl.UpGateOff -= TurnGateOff;
            TrackMoverControl.DownGateOff -= TurnGateOff;
        }



        private void TurnGateOff(string direction)
        {
            switch (direction)
            {
                case "right":
                    if (isRightGate)
                    {
                        DeactivateGate();
                    }
                    break;
                case "left":
                    if (isLeftGate)
                    {
                        DeactivateGate();
                    }
                    break;
                case "up":
                    if (isUpGate)
                    {
                        DeactivateGate();
                    }
                    break;
                case "down":
                    if (isDownGate)
                    {
                        DeactivateGate();
                    }
                    break;

            }
        }

        private void DeactivateGate()
        {
            _gate.SetActive(false);
            Invoke(nameof(ResetGate), 5);
        }

        private void ResetGate()
        {
            _gate.SetActive(true);
        }
    }
}

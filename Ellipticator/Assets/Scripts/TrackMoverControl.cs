using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tracks
{
    public class TrackMoverControl : MonoBehaviour
    {

      //  [SerializeField] private GameObject[] _streightTracks;
      //  [SerializeField] private GameObject[] _curveTracks;

        [SerializeField] private List<GameObject> _availableTracks = new List<GameObject>();
       

        int newTrack;
      


        // Start is called before the first frame update
        void Start()
        {
            SetTracksState(false);
            _availableTracks[0].SetActive(true);
          
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PickNextTrack()
        {
             newTrack = (newTrack + Random.Range(1, _availableTracks.Count - 1)) % _availableTracks.Count;
            _availableTracks[newTrack].SetActive(true);
     
        }


        /* private void NextTrack(int track)
        {
           switch (track)
            {
                case 0:
                    _streightTracks[0].SetActive(true);
                   
                    Debug.Log(trackNum);
                    break;
                case 1:
                    _streightTracks[1].SetActive(true);
                   
                    Debug.Log(trackNum);
                    break;
                case 2:
                    _curveTracks[0].SetActive(true);
                    break;
                case 3:
                    _curveTracks[1].SetActive(true);
                    break;
            }*/
    

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


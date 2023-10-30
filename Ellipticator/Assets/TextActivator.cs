using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;
using Meta.WitAi;
using UnityEngine;


public class TextActivator : MonoBehaviour
{

    [SerializeField] private VoiceService _voiceService;


    private string[] _directions = new string[] { "streight", "right", "left", "up", "down" };

    [SerializeField] private string[] _requests;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {
        int index = 0;
        _requests = new string[_directions.Length];
        for (int d = 0; d < _directions.Length; d++)
        {
            _requests[index] = $"{_directions[d]}";
            index++;

        }

    }

    public void SendVoiceRequests()
    {
        foreach (var request in _requests)
        {
            _voiceService.Activate(request);
        }
    }
}

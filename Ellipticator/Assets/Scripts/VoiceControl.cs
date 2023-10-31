using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;
using Meta.WitAi;


public class VoiceControl : MonoBehaviour
{
   [SerializeField] private AppVoiceExperience _appVoiceExperience;

    bool voiceActivate;
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateVoice(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateVoice(bool state)
    {
        _appVoiceExperience.enabled = state;
    }

    public void ChangeDirection (string direction)
    {
        switch (direction)
        {
            case "right":
                Debug.Log("direction" + direction);
                break;
            case "left":
                Debug.Log("direction" + direction);
                break;
            case "up":
                Debug.Log("direction" + direction);
                break;
            case "down":
                Debug.Log("direction" + direction);
                break;
        }
    }
}

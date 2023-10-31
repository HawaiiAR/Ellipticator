
using UnityEngine;
using Oculus.Voice;
using Oculus.VoiceSDK.UX;
using Meta.WitAi;
using Meta.WitAi.Requests;
using UnityEngine.UI;

public class VoiceControl : MonoBehaviour
{
    [SerializeField] private Image _micImage;

    [SerializeField] private Color _recordingColor;
    [SerializeField] private Color _inactiveColor;

    [SerializeField] private VoiceService _voiceService;
    [SerializeField] private bool _activateImmediately = false;
    [SerializeField] private bool _deactivateAndAbort = false;

    bool voiceActivate;
    private VoiceServiceRequest _request;
    private bool _isActive = false;


    private void Awake()
    {
        _inactiveColor = Color.red;
        _recordingColor = Color.green;
        _micImage.material.color = _recordingColor;   

        if (_voiceService == null)
        {
            _voiceService = FindObjectOfType<VoiceService>();
        }
        Deactivate();
    }

    public void Activate()
    {
        _micImage.material.color = _recordingColor;
        if (!_activateImmediately)
        {
           _request = _voiceService.Activate(GetRequestEvents());
        }
        else
        {
            _request = _voiceService.ActivateImmediately(GetRequestEvents());
        }
        Invoke(nameof(Deactivate), 3);
    }

    // Deactivate depending on settings
    private void Deactivate()
    {
        _micImage.material.color = _inactiveColor;
        Debug.Log("voice activator deactivated");
        if (!_deactivateAndAbort)
        {
            _request.DeactivateAudio();
        }
        else
        {
            _request.Cancel();
        }
    }

    private VoiceServiceRequestEvents GetRequestEvents()
    {
        VoiceServiceRequestEvents events = new VoiceServiceRequestEvents();
        events.OnInit.AddListener(OnInit);
        events.OnComplete.AddListener(OnComplete);
        return events;
    }
    // Request initialized
    private void OnInit(VoiceServiceRequest request)
    {
        _isActive = true;
    
    }
    // Request completed
    private void OnComplete(VoiceServiceRequest request)
    {
        _isActive = false;
      
    }
}



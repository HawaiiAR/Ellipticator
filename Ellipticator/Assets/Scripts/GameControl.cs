using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControl : MonoBehaviour
{
    public static Action GameStarted;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _tracks;
    // Start is called before the first frame update
    void Start()
    {
        _tracks.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameStarted?.Invoke();
        _tracks.transform.position = _menu.transform.position;
        _tracks.transform.rotation = _menu.transform.rotation;
        _menu.SetActive(false);
        _tracks.SetActive(true);
    }
}

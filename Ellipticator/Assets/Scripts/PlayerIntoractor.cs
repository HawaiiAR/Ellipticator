using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerIntoractor : MonoBehaviour
{

    public static Action<string> PlayerHealthState;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private int _playerHealth;

    [SerializeField] private Color _startColor;
    [SerializeField] private Color _damageColor;
    [SerializeField] private AudioSource _audio;

    [SerializeField] private float _fadeTime;
    private float _time;

    bool isAlive;
    bool isHit;

    // Start is called before the first frame update
    void Start()
    {
       
        isAlive = true;
    }

    private void OnDisable()
    {

    }

    private void PlayerTakeDamage()
    {
        _time = 0;
        _mainCamera.backgroundColor = _damageColor;
        isHit = true;
//_audio.Play();
        _playerHealth -= 1;

        // StartCoroutine(DamageFader());
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            if (_time < _fadeTime)
            {
                _time += Time.deltaTime / _fadeTime;
                _mainCamera.backgroundColor = Color.Lerp(_damageColor, _startColor, _time);

            }
            else
            {
                isHit = false;
            }

        }
        if (isAlive)
        {
            if (_playerHealth <= 0)
            {
                PlayerHealthState?.Invoke("lose");
                isAlive = false;
            }
        }

    }

    private void CheckPlayerHealth()
    {
        if (_playerHealth <= 0)
        {
            PlayerHealthState?.Invoke("lose");

        }
        if (_playerHealth > 0)
        {
            PlayerHealthState?.Invoke("win");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            PlayerTakeDamage();
            Debug.Log("hit wall");
        }

        if (other.CompareTag("Mine"))
        {
            PlayerTakeDamage();
            Destroy(other.gameObject);
        }
    }

}

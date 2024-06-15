using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    private static PauseController instance;

    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    [SerializeField]
    private bool _isPaused = true;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // to begin in pause until the player click on play
        Time.timeScale = 0;
        GamePaused?.Invoke();
        if (!_isPaused)
        {
            Pause();
        }
        /*
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;

            Pause();
        }
    }

    private void Pause()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
            GamePaused?.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            GameResumed?.Invoke();
        }
    }

    public void SetIsPaused(bool isPaused)
    {
        _isPaused = isPaused;
        Pause();
    }

    public static PauseController GetInstance()
    {
        return instance == null ? instance = new PauseController() : instance;
    }
}

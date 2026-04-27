using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGamePaused;
    public GameObject _pauseMenu;

    public enum GlitchLevel
    {
        normalGlitch,
        LowGlitch,
        NoGlitch,
    }

    public GlitchLevel glitchLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager Instance { get; private set; }

    private void Awake()
    { // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
        _isGamePaused = false;
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if (!_isGamePaused)
        {
            _isGamePaused = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (_isGamePaused)
        {
            _isGamePaused = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void UpdateGlitch(int val)
    {
        glitchLevel = val switch
        {
            1 => GlitchLevel.LowGlitch,
            2 => GlitchLevel.NoGlitch,
            _ => GlitchLevel.normalGlitch,
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private SettingsUI _settings;

    private GameObject _openSettings = null;

    void Update()
    {
        if (_openSettings) return;

        _canvas.enabled = true; // not ideal to set every frame...
    }

    #region BUTTONS

    public void Resume()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void Settings()
    {
        _canvas.enabled = false;
        _openSettings = Instantiate(_settings, transform).gameObject;
    }

    public void Quit()
    {
        // TODO return to main menu
    }

    #endregion
}

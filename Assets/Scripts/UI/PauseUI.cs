using UnityEngine;

public class PauseUI : MonoBehaviour
{
    #region VARIABLE

    [Header("Game pause")]
    [Tooltip("Request change to next scene (main menu)")]
    [SerializeField] private IntEventChannel _sceneEvent;
    [Tooltip("Canvas to display resume, settings and quit buttons")]
    [SerializeField] private Canvas _canvas;
    [Tooltip("Canvas to display and change user settings")]
    [SerializeField] private SettingsUI _settings;

    private GameObject _openSettings = null;

    #endregion

    void Update()
    {
        if (_openSettings) return;

        _canvas.enabled = true; // not ideal to set every frame...
    }

    #region BUTTON

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
        _sceneEvent.RaiseIntEvent(1);
    }

    #endregion
}

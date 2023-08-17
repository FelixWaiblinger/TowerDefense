using UnityEngine;

public class MenuUI : MonoBehaviour
{
    #region VARIABLE

    [Header("Main menu")]
    [Tooltip("Main canvas holding start, settings and quit button")]
    [SerializeField] private Canvas _canvas;
    [Tooltip("Canvas to display and change user settings")]
    [SerializeField] private SettingsUI _settings;
    [Tooltip("Request change to next scene (main game)")]
    [SerializeField] private IntEventChannel _sceneEvent;

    private GameObject _openSettings = null;

    #endregion

    void Update()
    {
        if (!_canvas.enabled && !_openSettings)
            _canvas.enabled = true;
    }

    #region BUTTON

    public void Play()
    {
        _sceneEvent.RaiseIntEvent(2);
    }

    public void Settings()
    {
        _canvas.enabled = false;
        _openSettings = Instantiate(
            _settings,
            Vector3.zero,
            Quaternion.identity
        ).gameObject;
    }

    public void Quit()
    {
        // TODO save stuff
        Application.Quit();
    }

    #endregion
}

using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private SettingsUI _settings;
    [SerializeField] private IntEventChannel _sceneEvent;

    private GameObject _openSettings = null;

    void Update()
    {
        if (!_canvas.enabled && !_openSettings)
            _canvas.enabled = true;
    }

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
}

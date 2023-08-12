using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameData _gameInfo;

    [Header("UI elements")]
    [SerializeField] private Slider _musicLevel;
    [SerializeField] private Slider _effectsLevel;

    public void Return()
    {
        _gameInfo.MusicLevel = _musicLevel.value;
        _gameInfo.EffectsLevel = _effectsLevel.value;

        Destroy(gameObject);
    }
}

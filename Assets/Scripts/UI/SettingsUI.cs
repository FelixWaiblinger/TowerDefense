using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    #region VARIABLE

    [Header("Settings")]
    [Tooltip("Holds information about the start/on-going game and user options")]
    [SerializeField] private GameData _gameInfo;
    [Tooltip("Display and change the volume level of music")]
    [SerializeField] private Slider _musicLevel;
    [Tooltip("Display and change the volume level of sound effects")]
    [SerializeField] private Slider _effectsLevel;

    #endregion

    #region BUTTON

    public void Return()
    {
        _gameInfo.MusicLevel = _musicLevel.value;
        _gameInfo.EffectsLevel = _effectsLevel.value;

        Destroy(gameObject);
    }

    #endregion
}

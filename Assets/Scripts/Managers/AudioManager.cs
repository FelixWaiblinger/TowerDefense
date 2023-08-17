using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region VARIABLE

    [Header("Events")]
    [Tooltip("Change current music theme")]
    [SerializeField] private IntEventChannel _audioEvent;
    [Tooltip("Change current music volume level")]
    [SerializeField] private VoidEventChannel _volumeEvent;
    [Tooltip("Holds information about the start/on-going game and user options")]
    [SerializeField] private GameData _gameInfo;

    [Header("Audio")]
    [Tooltip("Collection of music themes")]
    [SerializeField] private AudioClip[] _music; // 0 = menu, 1 = day, 2 = night
    [Tooltip("Collection of sound effects")]
    [SerializeField] private AudioClip[] _effects; // 0 = ..., 1 = ...

    private AudioSource _musicPlayer;
    private List<AudioSource> _effectsPlayer = new List<AudioSource>();

    #endregion

    #region SETUP

    void OnEnable()
    {
        _audioEvent.OnIntEventRaised += PlayTheme;
        _volumeEvent.OnVoidEventRaised += ApplyOptions;
    }

    void OnDisable()
    {
        _audioEvent.OnIntEventRaised -= PlayTheme;
        _volumeEvent.OnVoidEventRaised -= ApplyOptions;
    }

    #endregion

    #region EVENT

    void PlayTheme(int index)
    {
        _musicPlayer.clip = _music[index];
        _musicPlayer?.Play();
    }

    void ApplyOptions()
    {
        _musicPlayer.volume = _gameInfo.MusicLevel;

        // TODO apply effects volume
    }
    
    #endregion
}

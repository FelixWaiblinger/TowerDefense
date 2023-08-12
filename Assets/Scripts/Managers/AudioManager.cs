using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private IntEventChannel _audioEvent;
    [SerializeField] private VoidEventChannel _volumeEvent;
    [SerializeField] private GameData _gameInfo;

    [Header("Audio")]
    // 0 = menu, 1 = day, 2 = night
    [SerializeField] private AudioClip[] _music;
    // 0 = ..., 1 = ...
    [SerializeField] private AudioClip[] _effects;

    private AudioSource _musicPlayer;
    private List<AudioSource> _effectsPlayer = new List<AudioSource>();

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
}

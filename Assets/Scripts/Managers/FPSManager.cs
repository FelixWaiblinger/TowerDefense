using UnityEngine;
using TMPro;

public class FPSHandler : MonoBehaviour
{
    #region VARIABLE
    
    [Header("Framerate")]
    [Tooltip("Framerate to target at all times")]
    [SerializeField] private int _targetFPS = 60;
    [Tooltip("Display current framerate in top-right corner")]
    [SerializeField] private bool _showFPS = false;
    [Tooltip("Canvas to display the framerate in")]
    [SerializeField] private GameObject _framesUI;
    [Tooltip("Text box in top-right corner")]
    [SerializeField] private TMP_Text _FPS;

    #endregion

    void Start()
    {
        Application.targetFrameRate = _targetFPS;
        if (_showFPS) _framesUI.SetActive(true);
    }

    void FixedUpdate() // yes this is intentional
    {
        _FPS.text = $"{(int)(1 / Time.deltaTime)} FPS";
    }
}

using UnityEngine;
using TMPro;

public class FPSHandler : MonoBehaviour
{
    [SerializeField] private int _targetFPS = 60;
    [SerializeField] private bool _showFPS = false;
    [SerializeField] private GameObject _framesUI;
    [SerializeField] private TMP_Text _FPS;

    void Start()
    {
        Application.targetFrameRate = _targetFPS;
        if (_showFPS) _framesUI.SetActive(true);
    }

    void FixedUpdate()
    {
        _FPS.text = $"{(int)(1 / Time.deltaTime)} FPS";
    }
}

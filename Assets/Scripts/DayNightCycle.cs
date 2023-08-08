using System.Collections;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] VoidEventChannel _switchEvent;
    [SerializeField] bool _smoothTransition = true;
    [SerializeField] float _dayTime = 60;
    [SerializeField] float _nightTime = 60;
    [SerializeField] float _dayColorDelta = 3000;
    [SerializeField] float _nightColorDelta = 100;
    
    Quaternion _dayStartRotation = Quaternion.Euler(50, 120, 0);
    Quaternion _dayEndRotation = Quaternion.Euler(50, -30, 0);
    Quaternion _nightStartRotation = Quaternion.Euler(90, 120, 0);

    Light _directionalLight;
    bool _day = true, _inTransition = false;
    float _currentTime = 0, _dayColorChange, _nightColorChange, _dayRotationChange;

    #region SETUP

    void OnEnable()
    {
        _switchEvent.OnVoidEventRaised += Transition;
    }

    void OnDisable()
    {
        _switchEvent.OnVoidEventRaised -= Transition;
    }

    void Start()
    {
        _directionalLight = gameObject.GetComponent<Light>();
        _dayColorChange = _dayColorDelta / _dayTime;
        _nightColorChange = _nightColorDelta / _nightTime;
        _dayRotationChange = 150f / _dayTime;
    }

    #endregion

    void Update()
    {
        if (_inTransition) return;

        _currentTime += Time.deltaTime;

        if (_day ? UpdateDay() : UpdateNight())
            Transition();
    }

    bool UpdateDay()
    {
        _directionalLight.colorTemperature += _dayColorChange * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _dayEndRotation,
            Time.deltaTime * _dayRotationChange
        );

        return _currentTime > _dayTime;
    }

    bool UpdateNight()
    {
        _directionalLight.colorTemperature +=
            Time.deltaTime * Random.Range(-_nightColorChange, _nightColorChange);

        return _currentTime > _nightTime;
    }

    void Transition()
    {
        _currentTime = 0;
        _day = !_day;
        var targetRot = _day ? _dayStartRotation : _nightStartRotation;

        if (_smoothTransition)
        {
            _inTransition = true;
            StartCoroutine(SmoothTransition(targetRot));
        }
        else
        {
            transform.rotation = targetRot;
        }
    }

    IEnumerator SmoothTransition(Quaternion targetRot)
    {
        while (transform.rotation != targetRot)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 1);
            yield return null;
        }

        _inTransition = false;
    }
}

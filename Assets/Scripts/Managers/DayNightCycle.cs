using System.Collections;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] VoidEventChannel _defendEvent;
    [Tooltip("Day&Night transition smooth or instantaneous")]
    [SerializeField] bool _smoothTransition = true;
    [Tooltip("Higher value for faster transition")]
    [SerializeField] float _smoothness = 0.5f;
    [Tooltip("Day&Night transition after given time or event-based only")]
    [SerializeField] bool _timedTransition = true;
    [Tooltip("Time in seconds until the day ends")]
    [SerializeField] float _dayTime = 60;
    [Tooltip("Time in seconds until the night ends")]
    [SerializeField] float _nightTime = 60;
    [Tooltip("Shift in color temperature over entire day")]
    [SerializeField] float _dayColorDelta = 3000;
    [Tooltip("Random variations in color temperature during the night")]
    [SerializeField] float _nightColorDelta = 100;
    
    Quaternion _dayStartRotation = Quaternion.Euler(50, 120, 0);
    Quaternion _dayEndRotation = Quaternion.Euler(50, -30, 0);
    Quaternion _nightStartRotation = Quaternion.Euler(90, 120, 0);

    Light _directionalLight;
    bool _day = true, _inTransition = false;
    float _dayColor = 5000, _nightColor = 8000;
    float _currentTime = 0, _dayColorChange, _nightColorChange, _dayRotationChange;

    #region SETUP

    void OnEnable()
    {
        _defendEvent.OnVoidEventRaised += Transition;
    }

    void OnDisable()
    {
        _defendEvent.OnVoidEventRaised -= Transition;
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
        if (!_timedTransition) return; // event-based transitions only

        if (_inTransition) return;

        _currentTime += Time.deltaTime;

        if (_day ? UpdateDay() : UpdateNight()) Transition();
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
        _directionalLight.colorTemperature = _day ? _dayColor : _nightColor;
        var targetRot = _day ? _dayStartRotation : _nightStartRotation;

        if (_smoothTransition) StartCoroutine(SmoothTransition(targetRot));
        else transform.rotation = targetRot;
    }

    IEnumerator SmoothTransition(Quaternion targetRot)
    {
        _inTransition = true;

        while (transform.rotation != targetRot)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                _smoothness
            );

            yield return null;
        }

        _inTransition = false;
    }
}

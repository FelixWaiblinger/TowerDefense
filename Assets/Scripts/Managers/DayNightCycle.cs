using System.Collections;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    #region VARIABLE

    [SerializeField] private BoolEventChannel _transitionEvent;
    [Tooltip("Day&Night transition smooth or instantaneous")]
    [SerializeField] private bool _smoothTransition = true;
    [Tooltip("Higher value for faster transition")]
    [SerializeField] private float _smoothness = 0.5f;
    [Tooltip("Day&Night transition after given time or event-based only")]
    [SerializeField] private bool _timedTransition = true;
    [Tooltip("Time in seconds until the day ends")]
    [SerializeField] private float _dayTime = 60;
    [Tooltip("Time in seconds until the night ends")]
    [SerializeField] private float _nightTime = 60;
    [Tooltip("Shift in color temperature over entire day")]
    [SerializeField] private float _dayColorDelta = 3000;
    [Tooltip("Random variations in color temperature during the night")]
    [SerializeField] private float _nightColorDelta = 100;
    
    private Quaternion _dayStartRotation = Quaternion.Euler(50, 120, 0);
    private Quaternion _dayEndRotation = Quaternion.Euler(50, -30, 0);
    private Quaternion _nightStartRotation = Quaternion.Euler(90, 120, 0);

    private Light _directionalLight;
    private bool _isDay = true, _inTransition = false;
    private float _dayColor = 5000, _nightColor = 8000, _currentTime = 0;
    private float _dayColorChange, _nightColorChange, _dayRotationChange;

    #endregion

    #region SETUP

    void OnEnable()
    {
        _transitionEvent.OnBoolEventRaised += Transition;
    }

    void OnDisable()
    {
        _transitionEvent.OnBoolEventRaised -= Transition;
    }

    void Start()
    {
        _directionalLight = gameObject.GetComponent<Light>();
        _dayColorChange = _dayColorDelta / _dayTime;
        _nightColorChange = _nightColorDelta / _nightTime;
        _dayRotationChange = 150f / _dayTime;
    }

    #endregion

    #region UPDATE

    void Update()
    {
        // event-based transitions only
        if (!_timedTransition) return;

        // the sun does not move during dusk and dawn
        if (_inTransition) return;

        _currentTime += Time.deltaTime;

        if (_isDay ? UpdateDay() : UpdateNight()) Transition(!_isDay);
    }

    bool UpdateDay()
    {
        // light temperature
        _directionalLight.colorTemperature += _dayColorChange * Time.deltaTime;

        // sun position
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _dayEndRotation,
            Time.deltaTime * _dayRotationChange
        );

        return _currentTime > _dayTime;
    }

    bool UpdateNight()
    {
        // light temperature
        _directionalLight.colorTemperature +=
            Time.deltaTime * Random.Range(-_nightColorChange, _nightColorChange);

        return _currentTime > _nightTime;
    }

    #endregion

    #region EVENT

    void Transition(bool isDay)
    {
        _currentTime = 0;
        _isDay = isDay;
        _directionalLight.colorTemperature = _isDay ? _dayColor : _nightColor;
        var targetRot = _isDay ? _dayStartRotation : _nightStartRotation;

        if (_smoothTransition) StartCoroutine(SmoothTransition(targetRot));
        else transform.rotation = targetRot;
    }

    #endregion

    #region COROUTINE

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
    
    #endregion
}

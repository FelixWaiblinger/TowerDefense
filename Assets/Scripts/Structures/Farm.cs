using UnityEngine;

public class Farm : Structure
{
    #region VARIABLE

    [Header("Farm")]
    [Tooltip("Notification of a change in the day/night cycle")]
    [SerializeField] private BoolEventChannel _transitionEvent;
    [Tooltip("Sending the generated income to a GameManager")]
    [SerializeField] private IntEventChannel _moneyEvent;
    [Tooltip("Amount of money this farm generates per day")]
    [SerializeField] private int _incomeAmount;

    #endregion

    #region SETUP

    void OnEnable()
    {
        _transitionEvent.OnBoolEventRaised += GenerateIncome;
    }

    void OnDisable()
    {
        _transitionEvent.OnBoolEventRaised -= GenerateIncome;
    }

    #endregion

    void Update()
    {
        OnDestruction();
    }

    #region EVENT

    void GenerateIncome(bool isDay)
    {
        if (isDay) _moneyEvent.RaiseIntEvent(_incomeAmount);
    }

    #endregion
}

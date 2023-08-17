using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region VARIABLE

    [Header("Events")]
    [Tooltip("Notification of a change in day/night cycle")]
    [SerializeField] private BoolEventChannel _transitionEvent;
    [Tooltip("Request to change to next step in day/night cycle")]
    [SerializeField] private VoidEventChannel _requestTransitionEvent;
    [Tooltip("Add/Subtract money to/from players resources")]
    [SerializeField] private IntEventChannel _moneyEvent;
    [Tooltip("Add/Subtract research to/from players resources")]
    [SerializeField] private IntEventChannel _researchEvent;
    [Tooltip("Trigger the end of a game")]
    [SerializeField] private BoolEventChannel _winEvent;

    [Header("UI")]
    [Tooltip("Canvas to display turn, resources, build options, ...")]
    [SerializeField] private GameUI _HUD;
    [Tooltip("Canvas to display summary of lost game")]
    [SerializeField] private SummaryUI _summary;

    [Header("Data storage")]
    [Tooltip("Holds information about the start/on-going game and user options")]
    [SerializeField] private GameData _gameInfo;
    [Tooltip("Holds statistical information like kills, damages, scores, ...")]
    [SerializeField] private StatisticData _statistics;
    [Tooltip("Holds information about acquired upgrades")]
    [SerializeField] private UpgradeData _upgrades;

    private bool _isDay = true;
    private int _money;
    private int _research;

    #endregion

    #region SETUP

    void OnEnable()
    {
        _requestTransitionEvent.OnVoidEventRaised += EndTurn;
        _moneyEvent.OnIntEventRaised += HandleMoney;
        _researchEvent.OnIntEventRaised += HandleResearch;
        _winEvent.OnBoolEventRaised += GameOver;
    }

    void OnDisable()
    {
        _requestTransitionEvent.OnVoidEventRaised -= EndTurn;
        _moneyEvent.OnIntEventRaised -= HandleMoney;
        _researchEvent.OnIntEventRaised -= HandleResearch;
        _winEvent.OnBoolEventRaised -= GameOver;
    }

    void Start()
    {
        _money = _gameInfo.StartMoney;
        _research = _gameInfo.StartResearch;
    }

    #endregion

    void Update()
    {
        if (_isDay)
        {

        }
        else
        {

        }
    }

    #region EVENT

    void EndTurn()
    {
        _isDay = !_isDay;
        _transitionEvent.RaiseBoolEvent(_isDay);
    }

    void HandleMoney(int amount)
    {
        // receive money OR spend money if you have enough
        if (amount > 0 || _money > amount)
        {
            _money += amount;
            _HUD.UpdateMoney(_money);
        }
    }

    void HandleResearch(int amount)
    {
        // receive research OR spend research if you have enough
        if (amount > 0 || _research > amount)
        {
            _research += amount;
            _HUD.UpdateResearch(_research);
        }
    }

    void GameOver(bool isWon)
    {
        // TODO isWon ?
        Instantiate(_summary, Vector3.zero, Quaternion.identity);
        Time.timeScale = 0; // is this a good idea?
    }

    #endregion
}

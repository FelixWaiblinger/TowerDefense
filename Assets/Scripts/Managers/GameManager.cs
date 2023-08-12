using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private VoidEventChannel _defendEvent;
    [SerializeField] private VoidEventChannel _loseEvent;
    [SerializeField] private VoidEventChannel _winEvent;

    [Header("UI")]
    [SerializeField] private GameUI _HUD;
    [SerializeField] private LoseUI _gameOver;

    [Header("Data storage")]
    [SerializeField] private GameData _gameInfo;
    [SerializeField] private StatisticData _statistics;
    [SerializeField] private UpgradeData _upgrades;

    private bool _day = true;
    private int _money;
    private int _research;

    #region SETUP

    void OnEnable()
    {
        _defendEvent.OnVoidEventRaised += EndTurn;
        _loseEvent.OnVoidEventRaised += GameOver;
    }

    void OnDisable()
    {
        _defendEvent.OnVoidEventRaised -= EndTurn;
        _loseEvent.OnVoidEventRaised -= GameOver;
    }

    void Start()
    {
        _money = _gameInfo.StartMoney;
        _research = _gameInfo.StartResearch;
    }

    #endregion

    void Update()
    {
        if (_day)
        {

        }
        else
        {

        }
    }

    void EndTurn()
    {
        _day = !_day;
    }

    void GameOver()
    {
        Instantiate(_gameOver, Vector3.zero, Quaternion.identity);
        Time.timeScale = 0; // is this a good idea?
    }
}

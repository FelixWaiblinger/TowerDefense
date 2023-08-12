using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _defendEvent;
    [SerializeField] private VoidEventChannel _loseEvent;
    [SerializeField] private VoidEventChannel _winEvent;

    [SerializeField] private LoseUI _gameOver;
    [SerializeField] private StatisticData _statistics;
    [SerializeField] private UpgradeData _upgrades;

    private bool _day = true;

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

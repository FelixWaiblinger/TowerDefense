using System.Collections.Generic;
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
    [Tooltip("Notification when all enemies of a spawner have been killed")]
    [SerializeField] private VoidEventChannel _spawnerEvent;

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

    [Header("Enemies")]
    [Tooltip("Dynamically updated list of enemy spawners")]
    [SerializeField] private List<EnemySpawner> _spawners;

    private bool _isDay = true;
    private int _day = 1;
    private int _spawnersStopped = 0;
    private int _money;
    private int _research;

    #endregion

    #region SETUP

    void OnEnable()
    {
        _requestTransitionEvent.OnVoidEventRaised += StartFight;
        _moneyEvent.OnIntEventRaised += HandleMoney;
        _researchEvent.OnIntEventRaised += HandleResearch;
        _winEvent.OnBoolEventRaised += GameOver;
        _spawnerEvent.OnVoidEventRaised += HandleEnemies;
    }

    void OnDisable()
    {
        _requestTransitionEvent.OnVoidEventRaised -= StartFight;
        _moneyEvent.OnIntEventRaised -= HandleMoney;
        _researchEvent.OnIntEventRaised -= HandleResearch;
        _winEvent.OnBoolEventRaised -= GameOver;
        _spawnerEvent.OnVoidEventRaised -= HandleEnemies;
    }

    void Start()
    {
        _money = _gameInfo.StartMoney;
        _research = _gameInfo.StartResearch;
    }

    #endregion

    void EndTurn()
    {
        _isDay = !_isDay;
        _spawnersStopped = 0;
        _transitionEvent.RaiseBoolEvent(_isDay);
    }

    void CreateSpawner(int difficulty)
    {
        var index = Random.Range(0, difficulty);
        // TODO find better random positions
        var position = new Vector3(
            Random.Range(0f, 1f) > 0.5 ? 20 : -20,
            0,
            Random.Range(0f, 1f) > 0.5 ? 20 : -20
        );
        var rotation = Quaternion.LookRotation(-position);

        _spawners.Add(Instantiate(_gameInfo.EnemyTypes[index], position, rotation));
    }

    void IncreaseDifficulty()
    {
        int enemyTypes = 1;
        int newSpawners = 1;

        switch (_day)
        {
            case <4:
                Debug.Log("Easy");
                break;

            case <7:
                Debug.Log("Medium");
                newSpawners = 2;
                enemyTypes = 5;
                break;

            case <10:
                Debug.Log("Hard");
                newSpawners = 3;
                enemyTypes = _gameInfo.EnemyTypes.Length - 1;
                break;
        }

        for (int i = 0; i < newSpawners; i++)
        {
            CreateSpawner(enemyTypes);
        }
    }

    #region EVENT

    void StartFight()
    {
        if (!_isDay) return;

        IncreaseDifficulty();

        EndTurn();
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

    void HandleEnemies()
    {
        _spawnersStopped++;

        if (_spawnersStopped == _spawners.Count)
        {
            _HUD.UpdateDay(++_day);
            EndTurn();
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

using UnityEngine;
using TMPro;

public class SummaryUI : MonoBehaviour
{
    #region VARIABLE

    [Header("Game Over")]
    [Tooltip("Request change to next scene")]
    [SerializeField] private IntEventChannel _sceneEvent;
    [Tooltip("Holds statistical information like kills, damages, scores, ...")]
    [SerializeField] private StatisticData _statistics;
    [Tooltip("Display number of days survived")]
    [SerializeField] private TMP_Text _dayCount;
    [Tooltip("Display number of structures built")]
    [SerializeField] private TMP_Text _structuresBuilt;
    [Tooltip("Display number of structures lost")]
    [SerializeField] private TMP_Text _structuresLost;
    [Tooltip("Display number of enemies killed")]
    [SerializeField] private TMP_Text _enemiesKilled;
    [Tooltip("Display number of elite enemies killed")]
    [SerializeField] private TMP_Text _eliteEnemiesKilled;

    #endregion
    
    void Start()
    {
        _dayCount.text = _statistics.DayCount.ToString();
        _structuresBuilt.text = _statistics.StructuresBuilt.ToString();
        _structuresLost.text = _statistics.StructuresLost.ToString();
        _enemiesKilled.text = _statistics.EnemiesKilled.ToString();
        _eliteEnemiesKilled.text = _statistics.EliteEnemiesKilled.ToString();
    }

    #region BUTTON

    public void Retry()
    {
        _sceneEvent.RaiseIntEvent(2);
    }

    public void Quit()
    {
        _sceneEvent.RaiseIntEvent(1);
    }

    #endregion
}

using UnityEngine;
using TMPro;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private StatisticData _statistics;
    [SerializeField] private TMP_Text _dayCount;
    [SerializeField] private TMP_Text _structuresBuilt;
    [SerializeField] private TMP_Text _structuresLost;
    [SerializeField] private TMP_Text _enemiesKilled;
    [SerializeField] private TMP_Text _eliteEnemiesKilled;
    
    void Start()
    {
        _dayCount.text = _statistics.DayCount.ToString();
        _structuresBuilt.text = _statistics.StructuresBuilt.ToString();
        _structuresLost.text = _statistics.StructuresLost.ToString();
        _enemiesKilled.text = _statistics.EnemiesKilled.ToString();
        _eliteEnemiesKilled.text = _statistics.EliteEnemiesKilled.ToString();
    }
}

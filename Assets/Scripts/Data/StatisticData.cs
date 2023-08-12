using UnityEngine;

[CreateAssetMenu(fileName = "StatisticData", menuName = "Data/Statistic Data")]
public class StatisticData : ScriptableObject
{
    public int DayCount = 0;
    public int StructuresBuilt = 0;
    public int StructuresLost = 0;
    public int EnemiesKilled = 0;
    public int EliteEnemiesKilled = 0;
}

using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public int StartMoney = 100;
    public int StartResearch = 0;

    public float MusicLevel = 1;
    public float EffectsLevel = 1;

    public GameObject[] Structures;
    public EnemySpawner[] EnemyTypes;
}

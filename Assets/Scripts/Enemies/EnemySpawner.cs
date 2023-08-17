using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region VARIABLE

    [Header("Spawning behaviour")]
    [Tooltip("Trigger spawning the next wave of enemies")]
    [SerializeField] private VoidEventChannel _spawnEvent;
    [Tooltip("Enemy prefab to instantiate")]
    [SerializeField] private Enemy _enemyType;
    [Tooltip("Spawn all enemies immediately or over time")]
    [SerializeField] private bool _spawnAtOnce = true;
    [Tooltip("Number of enemies to spawn per wave")]
    [SerializeField] private int _spawnAmount = 1;
    [Tooltip("Enemies spawning per second (if spawning over time)")]
    [SerializeField] private float _spawnRate = 1; // per second
    [Tooltip("Offset enemies in front of spawner")]
    [SerializeField] private float _spawnOffsetFWD = 1;

    private float _currentTime = 0;
    private bool _spawn = false;
    private int _spawnCounter = 0;

    #endregion

    #region SETUP

    void OnEnable()
    {
        _spawnEvent.OnVoidEventRaised += SpawnEnemies;
    }

    void OnDisable()
    {
        _spawnEvent.OnVoidEventRaised -= SpawnEnemies;
    }

    #endregion

    void Update()
    {
        if (!_spawn) return;

        if (_spawnCounter < _spawnAmount)
        {
            _currentTime += Time.deltaTime;
            
            if (_currentTime > 1f / _spawnRate)
            {
                CreateEnemy();
                _currentTime = 0;
            }
        }
        else _spawn = false;
    }

    void SpawnEnemies()
    {
        _currentTime = 0;
        _spawnCounter = 0;

        if (_spawnAtOnce)
        {
            for (int i = 0; i < _spawnAmount; i++)
            {
                CreateEnemy();
            }
        }
        else _spawn = true;
    }

    void CreateEnemy()
    {
        var noise = Vector3.Scale(Random.insideUnitSphere, new Vector3(1, 0, 1));
        
        var enemy = Instantiate(
            _enemyType,
            transform.position + noise + transform.forward * _spawnOffsetFWD,
            Quaternion.identity
        );

        enemy.transform.SetParent(transform);
    }
}

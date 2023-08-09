using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _spawnEvent;
    [SerializeField] private Enemy _enemyType;
    [SerializeField] private bool _spawnAtOnce = true;
    [SerializeField] private int _spawnAmount = 1;
    [SerializeField] private float _spawnRate = 1; // per second
    [SerializeField] private Vector3 _spawnOffset = Vector3.forward;

    private float _currentTime = 0;
    private bool _spawn = false;
    private int _spawnCounter = 0;

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
            }
        }
        else
        {
            _spawn = false;
        }
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
        else
        {
            _spawn = true;
        }
    }

    void CreateEnemy()
    {
        var noise = Vector3.Scale(Random.insideUnitSphere, new Vector3(1, 1, 0));
        var enemy = Instantiate(_enemyType, _spawnOffset + noise, Quaternion.identity);
        enemy.transform.SetParent(transform);
    }
}

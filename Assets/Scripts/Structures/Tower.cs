using UnityEngine;

public abstract class Tower : Structure
{
    #region VARIABLE

    [Header("Tower")]
    [Tooltip("Projectile prefab to instantiate")]
    [SerializeField] protected Projectile _projectile;
    [Tooltip("Where to instantiate a new projectile")]
    [SerializeField] protected Transform _projectileStart;
    [Tooltip("Damage applied on-hit")]
    [SerializeField] protected int _attackDamage;
    [Tooltip("Attacks per second")]
    [SerializeField] protected float _attackRate;
    [Tooltip("Maximum range to detect enemies")]
    [SerializeField] protected float _attackRange;

    protected GameObject _currentTarget = null;
    protected float _attackTimer = 0;
    
    #endregion

    protected void FindTarget()
    {
        // find all enemies in range using their layer
        var enemies = Physics.OverlapSphere(transform.position, _attackRange, 11);
        
        if (enemies.Length == 0) return;
        
        // find closest enemy
        float minDistance = _attackRange;
        foreach (Collider e in enemies)
        {
            var distance = Vector3.Distance(e.transform.position, transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _currentTarget = e.gameObject;
            }
        }
    }

    protected void Attack()
    {
        // start attack
        if (_attackTimer == 0)
        {
            CreateProjectile();
            _attackTimer += Time.deltaTime;
        }
        // update timer for next attack
        else
        {
            _attackTimer = _attackTimer >= 1 / _attackRate ? 0 : _attackTimer + Time.deltaTime;
        }
    }

    protected void CreateProjectile()
    {
        var rotation = Quaternion.LookRotation(
            _currentTarget.transform.position - _projectileStart.position
        );

        var projectile = Instantiate(_projectile, _projectileStart.position, rotation);
        projectile.Init(_currentTarget);
    }
}

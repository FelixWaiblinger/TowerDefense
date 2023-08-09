using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _currentHealth;
    [SerializeField] protected int _attackDamage;
    [SerializeField] protected float _moveSpeed;

    protected Transform _globalTarget, _localTarget = null;

    protected void Start()
    {
        _globalTarget = GameObject.FindGameObjectWithTag("Nexus").transform;
    }

    protected void CheckLocalTarget()
    {
        // TODO
        // var towers = GameObject.FindGameObjectsWithTag("Tower");
        // 
        // foreach (tower
    }
}

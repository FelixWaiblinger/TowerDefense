using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EntityUI _status;

    [Header("Stats")]
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _attackDamage;
    [SerializeField] protected float _attackRate;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _moveSpeed;

    protected int _currentHealth;
    protected Transform _globalTarget, _localTarget = null;

    protected void Start()
    {
        _globalTarget = GameObject.FindGameObjectWithTag("Nexus").transform;
        _currentHealth = _maxHealth;
    }

    protected void FindLocalTarget()
    {
        var structures = Physics.OverlapSphere(transform.position, _attackRange, 10); // player layer
        
        if (structures.Length == 0) return;

        float minDistance = _attackRange;
        foreach (Collider s in structures)
        {
            var distance = Vector3.Distance(s.transform.position, transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _localTarget = s.transform;
            }
        }
    }

    protected abstract void Attack();
}

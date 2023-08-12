using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected EntityUI _status;

    [Header("Stats")]
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _attackDamage;
    [Tooltip("Attacks per second")]
    [SerializeField] protected float _attackRate;
    [SerializeField] protected float _attackRange;

    protected int _currentHealth;
    protected Enemy _currentTarget = null;
    protected Outline _outline;

    protected void Start()
    {
        _currentHealth = _maxHealth;
        _outline = gameObject.GetComponent<Outline>();
    }

    protected void OnMouseEnter()
    {
        _outline.enabled = true;
    }

    protected void OnMouseExit()
    {
        _outline.enabled = false;
    }

    void FindTarget()
    {
        // find all enemies in range using their layer
        var structures = Physics.OverlapSphere(transform.position, _attackRange, 11);
        
        if (structures.Length == 0) return;
        
        // find closest enemy
        float minDistance = _attackRange;
        foreach (Collider s in structures)
        {
            var distance = Vector3.Distance(s.transform.position, transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _currentTarget = s.gameObject.GetComponent<Enemy>();
            }
        }
    }

    protected abstract void Attack();
}

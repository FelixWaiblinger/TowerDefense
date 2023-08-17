using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region VARIABLE

    [Tooltip("Canvas to display health, status and other details of this instance")]
    [SerializeField] protected EntityUI _status;

    [Header("Stats")]
    [Tooltip("Starting HP of this enemy")]
    [SerializeField] protected int _maxHealth;
    [Tooltip("Amount of damage to apply with each attack")]
    [SerializeField] protected int _attackDamage;
    [Tooltip("Attacks per second")]
    [SerializeField] protected float _attackRate;
    [Tooltip("Maximum range to acquire a target to attack")]
    [SerializeField] protected float _attackRange;
    [Tooltip("Travel speed of this enemy")]
    [SerializeField] protected float _moveSpeed;

    protected int _currentHealth;
    protected Transform _globalTarget, _localTarget = null;
    protected Outline _outline;

    #endregion

    #region SETUP

    protected void Start()
    {
        _globalTarget = GameObject.FindGameObjectWithTag("Nexus").transform;
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

    #endregion

    protected void FindLocalTarget()
    {
        // find all enemies in range using their layer
        var structures = Physics.OverlapSphere(transform.position, _attackRange, 10); // player layer
        
        if (structures.Length == 0) return;

        // find closest enemy
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

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
    }
}

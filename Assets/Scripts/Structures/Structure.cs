using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    #region VARIABLE

    [Header("Structure")]
    [Tooltip("Amount of money necessary to build a new instance")]
    [SerializeField] protected int _buildCost;
    [Tooltip("Starting HP of this instance")]
    [SerializeField] protected int _maxHealth;
    [Tooltip("Canvas to display health, status and other details about this instance")]
    [SerializeField] protected EntityUI _status;

    protected int _currentHealth;
    protected Outline _outline;

    #endregion

    #region SETUP

    protected void Awake()
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

    #endregion

    protected virtual void OnDestruction()
    {
        if (_currentHealth <= 0)
        {
            // play animation
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
    }
}

using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _defendEvent;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _incomeAmount;
    [SerializeField] private int _incomeRate;
    
    private int _currentHealth;
    protected Outline _outline;

    void Awake()
    {
        _currentHealth = _maxHealth;
        _outline = gameObject.GetComponentInChildren<Outline>();
    }

    void OnMouseEnter()
    {
        _outline.enabled = true;
    }

    void OnMouseExit()
    {
        _outline.enabled = false;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

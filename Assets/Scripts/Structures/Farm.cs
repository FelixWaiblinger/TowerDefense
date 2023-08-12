using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _incomeAmount;
    [SerializeField] private int _incomeRate;
    
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

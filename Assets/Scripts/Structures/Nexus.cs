using UnityEngine;

public class Nexus : Tower
{
    [SerializeField] private VoidEventChannel _loseEvent;
    
    void Update()
    {
        if (_currentHealth <= 0)
        {
            _loseEvent.RaiseVoidEvent();
            Destroy(gameObject);
        }
    }

    protected override void Attack()
    {

    }
}

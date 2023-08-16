using UnityEngine;

public class Nexus : Tower
{
    [SerializeField] private VoidEventChannel _loseEvent;
    [SerializeField] private VoidEventChannel _defendEvent;
    
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

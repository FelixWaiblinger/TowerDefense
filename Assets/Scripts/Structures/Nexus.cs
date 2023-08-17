using UnityEngine;

public class Nexus : Tower
{
    #region VARIABLE

    [Header("Nexus")]
    [Tooltip("Notification to end the game")]
    [SerializeField] private VoidEventChannel _gameOverEvent;

    #endregion
    
    void Update()
    {
        OnDestruction();

        if (_currentTarget) Attack();
    }

    protected override void OnDestruction()
    {
        if (_currentHealth > 0)
        {
            _gameOverEvent.RaiseVoidEvent();
            // play animation
            Destroy(gameObject);
        }
    }
}

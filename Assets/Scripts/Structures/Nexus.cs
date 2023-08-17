using UnityEngine;

public class Nexus : Tower
{
    #region VARIABLE

    [Header("Nexus")]
    [Tooltip("Notification to end the game")]
    [SerializeField] private BoolEventChannel _winEvent;

    #endregion
    
    void Update()
    {
        OnDestruction();

        if (_currentTarget) Attack();
    }

    protected override void OnDestruction()
    {
        if (_currentHealth <= 0)
        {
            _winEvent.RaiseBoolEvent(false);
            // play animation
            Destroy(gameObject);
        }
    }
}

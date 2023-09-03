using UnityEngine;

public class Nexus : Tower
{
    #region VARIABLE

    [Header("Nexus")]
    [Tooltip("Notification to end the game")]
    [SerializeField] private BoolEventChannel _winEvent;

    #endregion
    
    void OnDestroy()
    {
        _winEvent.RaiseBoolEvent(false);
    }
}

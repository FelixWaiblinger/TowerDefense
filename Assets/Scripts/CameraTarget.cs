using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _switchEvent;

    void OnEnable()
    {
        InputReader.endDayEvent += () => _switchEvent.RaiseVoidEvent();
    }
}

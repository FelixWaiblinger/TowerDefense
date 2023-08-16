using UnityEngine;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float _moveSpeed = 30;
    [SerializeField] private float _minDistance = 1;
    [SerializeField] private float _maxDistance = 40;

    private CinemachineFramingTransposer _transposer;
    private Vector3 _moveDirection;
    private float _distanceMultiplier;

    #region SETUP

    void OnEnable()
    {
        InputReader.moveEvent += MoveTarget;
        InputReader.zoomEvent += Zoom;
    }

    void OnDisable()
    {
        InputReader.moveEvent -= MoveTarget;
        InputReader.zoomEvent -= Zoom;
    }

    void Start()
    {
        _transposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        _distanceMultiplier = 0.5f + Mathf.InverseLerp(_minDistance, _maxDistance, 10);
    }

    #endregion

    void Update()
    {
        // move camera target around
        var multiplier = _moveSpeed * Time.deltaTime * _distanceMultiplier;
        transform.position += _moveDirection * multiplier;
    }

    void MoveTarget(Vector2 direction)
    {
        // set direction to continuously move while holding down
        _moveDirection =
            Quaternion.AngleAxis(45, Vector3.up) * // fix skewed isometric movement
            new Vector3(direction.x, 0, direction.y);
    }

    void Zoom(Vector2 direction)
    {
        // zoom in an out
        _transposer.m_CameraDistance = Mathf.Clamp(
            _transposer.m_CameraDistance - direction.y,
            _minDistance,
            _maxDistance
        );

        // distance affects camera speed
        _distanceMultiplier = 0.5f + Mathf.InverseLerp(
            _minDistance,
            _maxDistance,
            _transposer.m_CameraDistance
        );
    }
}

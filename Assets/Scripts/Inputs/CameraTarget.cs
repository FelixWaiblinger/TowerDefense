using UnityEngine;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    #region VARIABLE

    [Header("Camera behaviour")]
    [Tooltip("Cinemachine camera gameobject")]
    [SerializeField] private CinemachineVirtualCamera _camera;
    [Tooltip("Travel speed of the camera")]
    [SerializeField] private float _moveSpeed = 30;
    [Tooltip("Camera distance when zoomed in completely")]
    [SerializeField] private Vector3 _minDistance = new Vector3(-10f, 8.165f, -10f);
    [Tooltip("Camera distance when zoomed out completely")]
    [SerializeField] private Vector3 _maxDistance = new Vector3(-40f, 90f, -40f);
    [Tooltip("Scroll speed")]
    [SerializeField] private float _scrollSpeed = 2f;

    [Header("To be removed later")]
    [SerializeField] private bool _moveAtScreenEdge = false; // remove later

    private CinemachineTransposer _transposer;
    private Vector3 _moveDirection;
    private float _distanceMultiplier = 0.5f;
    private float _right = Screen.width * 0.9f;
    private float _left = Screen.width * 0.1f;
    private float _up = Screen.height * 0.9f;
    private float _down = Screen.height * 0.1f;

    #endregion

    #region SETUP

    void OnEnable()
    {
        InputReader.moveEvent += MoveTarget;
        InputReader.movePosEvent += MoveMousePos;
        InputReader.zoomEvent += Zoom;
    }

    void OnDisable()
    {
        InputReader.moveEvent -= MoveTarget;
        InputReader.movePosEvent -= MoveMousePos;
        InputReader.zoomEvent -= Zoom;
    }

    void Start()
    {
        _transposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
    }

    #endregion

    void Update()
    {
        // move camera target around
        var multiplier = _moveSpeed * Time.deltaTime * _distanceMultiplier;
        transform.position += _moveDirection * multiplier;
    }

    #region EVENT

    void MoveTarget(Vector2 direction)
    {
        // set direction to continuously move while holding down
        // with fixed skewed isometric movement
        _moveDirection = Quaternion.AngleAxis(45, Vector3.up) *
                         new Vector3(direction.x, 0, direction.y);
    }

    void MoveMousePos(Vector2 mouse)
    {
        if (!_moveAtScreenEdge) return;

        // horizontal edges
        if (mouse.x > _right)
        {
            _moveDirection.x = Mathf.InverseLerp(_right, Screen.width, mouse.x);
        }
        else if (mouse.x < _left)
        {
            _moveDirection.x = -Mathf.InverseLerp(_left, 0, mouse.x);
        }
        else _moveDirection.x = 0;

        // vertical edges
        if (mouse.y > _up)
        {
            _moveDirection.z = Mathf.InverseLerp(_up, Screen.height, mouse.y);
        }
        else if (mouse.y < _down)
        {
            _moveDirection.z = -Mathf.InverseLerp(_down, 0, mouse.y);
        }
        else _moveDirection.z = 0;

        _moveDirection = Quaternion.AngleAxis(45, Vector3.up) * _moveDirection * 2;
    }

    void Zoom(Vector2 direction)
    {
        // zoom in an out
        var targetOffset = direction.y < 0 ? _maxDistance :
                           direction.y > 0 ? _minDistance :
                           _transposer.m_FollowOffset;

        _transposer.m_FollowOffset = Vector3.MoveTowards(
            _transposer.m_FollowOffset,
            targetOffset,
            _scrollSpeed
        );

        // distance affects camera speed
        _distanceMultiplier = 0.5f + 3 * Mathf.InverseLerp(
            _minDistance.y,
            _maxDistance.y,
            _transposer.m_FollowOffset.y
        );
    }

    #endregion
}

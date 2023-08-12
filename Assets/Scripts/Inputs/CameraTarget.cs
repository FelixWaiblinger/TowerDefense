using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    private Camera _camera;
    private Plane _ground = new(Vector3.up, Vector3.zero);

    #region SETUP

    void OnEnable()
    {
        InputReader.moveEvent += MoveTarget;
    }

    void OnDisable()
    {
        InputReader.moveEvent -= MoveTarget;
    }

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    #endregion

    void MoveTarget(Vector2 direction)
    {
        var ray = _camera.ScreenPointToRay(new Vector3(direction.x, direction.y, 0));
        _ground.Raycast(ray, out float enter);

        transform.position = ray.GetPoint(enter);
    }
}

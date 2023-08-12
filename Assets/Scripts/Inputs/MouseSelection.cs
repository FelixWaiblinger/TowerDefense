using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    // [SerializeField] private 

    private Camera _camera;

    private GameObject _currentSelection;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        
    }

    void SelectObject(Vector2 mousePosition)
    {
        var ray = _camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0));

        if (!Physics.Raycast(ray, out RaycastHit hit)) return;

        _currentSelection = hit.collider.gameObject;
    }
}

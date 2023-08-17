using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    #region VARIABLE

    [Header("Object selection")]
    [Tooltip("UI selection of structure to build")]
    [SerializeField] private IntEventChannel _buildOptionEvent;
    [Tooltip("Holds information about the start/on-going game and user options")]
    [SerializeField] private GameData _gameInfo;

    private Camera _camera;
    private Vector3 _mousePosition;
    private GameObject _selectedObject = null;
    private GameObject _selectedStructure = null;

    #endregion

    #region SETUP

    void OnEnable()
    {
        InputReader.selectEvent += SelectObject;
        InputReader.movePosEvent += (pos) => _mousePosition = new(pos.x, pos.y, 0);
        InputReader.cancelEvent += Deselect;
        _buildOptionEvent.OnIntEventRaised += SelectStructure;
    }

    void OnDisable()
    {
        InputReader.selectEvent -= SelectObject;
        InputReader.cancelEvent -= Deselect;
        _buildOptionEvent.OnIntEventRaised -= SelectStructure;
    }

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    #endregion

    #region EVENT

    void SelectObject()
    {
        var ray = _camera.ScreenPointToRay(_mousePosition);

        // no object under mouse cursor
        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("No object selected");
            _selectedObject = null;
            return;
        }

        _selectedObject = hit.collider.gameObject;

        // object is not a tile
        if (_selectedObject.layer != 9) return;

        if (_selectedObject.GetComponentInChildren<Tile>().Occupied) return;

        // any structure is currently selected through the build menu 
        if (_selectedStructure)
        {
            Debug.Log("Building structure");
            _selectedObject.GetComponentInChildren<Tile>().Build(_selectedStructure);
            _selectedObject = null;
        }
    }

    void Deselect()
    {
        _selectedObject = null;
        _selectedStructure = null;
    }

    public void SelectStructure(int index)
    {
        var structure = _gameInfo.Structures[index];

        // toggle selection on button press
        _selectedStructure = _selectedObject != structure ? structure : null;
    }

    #endregion
}

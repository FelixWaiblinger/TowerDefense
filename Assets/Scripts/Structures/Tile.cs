using UnityEngine;

public class Tile : MonoBehaviour
{
    private Transform _sceneStructures;
    private GameObject _structure;
    public bool Occupied { get; private set; } = false;

    void Start()
    {
        _sceneStructures = GameObject.FindGameObjectWithTag("Structures").transform;
    }

    public void Build(GameObject structure)
    {
        var position = Vector3.Scale(new(1, 0, 1), transform.position);
        _structure = Instantiate(structure, position, Quaternion.identity);
        _structure.transform.SetParent(_sceneStructures);
        Occupied = true;
    }
}

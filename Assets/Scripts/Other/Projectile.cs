using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region VARIABLE

    [Header("Projectile")]
    [Tooltip("Gameobject layers to which damage should be applied")]
    [SerializeField] private LayerMask _layerToTarget;
    [Tooltip("Amount of damage to apply")]
    [SerializeField] private int _damage;
    [Tooltip("Travel speed of this projectile")]
    [SerializeField] private float _speed;
    
    private GameObject _target;

    #endregion

    void OnTriggerEnter(Collider other)
    {
        // not an enemy
        if (other.gameObject.layer != _layerToTarget) return;

        if (other.gameObject != _target) return;

        switch (_layerToTarget.value)
        {
            // enemy shoots at structure
            case 10: _target.GetComponent<Structure>().TakeDamage(_damage); break;
            // structure shoots at enemy
            case 11: _target.GetComponent<Enemy>().TakeDamage(_damage); break;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.transform.position,
            _speed * Time.deltaTime
        );
    }

    public void Init(GameObject target)
    {
        _target = target;
    }
}

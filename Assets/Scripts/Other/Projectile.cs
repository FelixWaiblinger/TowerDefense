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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != _target) return;

        switch (Mathf.Log(_layerToTarget.value, 2))
        {
            // enemy shoots at structure
            case 10:
                other.gameObject.GetComponent<Structure>().TakeDamage(_damage);
                break;
            // structure shoots at enemy
            case 11:
                other.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
                break;
        }

        Destroy(gameObject);
    }

    void Update()
    {
        if (!_target) Destroy(gameObject);
        
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

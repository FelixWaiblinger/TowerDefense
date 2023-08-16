using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Manager : MonoBehaviour {
    public float _speed = 15f;
    public Vector3 _rotationOffset = new Vector3(0, 0, 0);

    private Rigidbody _rb;

    public GameObject[] Detachables;

    [Tooltip("Only for testing Purposes")]
    public GameObject selfPrefab;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        if (_speed != 0) {
            _rb.velocity = transform.forward * _speed;
            //transform.position += transform.forward * (speed * Time.deltaTime);

        }
    }
    private void OnCollisionEnter(Collision collision) {
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        _speed = 0;

        //Removing trail from the projectile on cillision enter or smooth removing. Detached elements must have "AutoDestroying script"
        foreach (var detachedPrefab in Detachables) {
            if (detachedPrefab != null) {
                detachedPrefab.transform.parent = null;
                Destroy(detachedPrefab, 1);
            }
        }
        //Destroy projectile on collision
        Destroy(gameObject);


    }
}

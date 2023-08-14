using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Manager : MonoBehaviour
{
    public float _speed = 15f;
    public Vector3 _rotationOffset = new Vector3(0, 0, 0);

    private Rigidbody _rb;

    public GameObject[] Detachables;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        if (_speed != 0) {
            _rb.velocity = transform.forward * _speed;
            //transform.position += transform.forward * (speed * Time.deltaTime);

        }
    }

}

using UnityEngine;

public class BlueEnemy : Enemy
{
    void Update()
    {
        CheckLocalTarget();

        transform.position = Vector3.MoveTowards(
            transform.position,
            _localTarget == null ? _globalTarget.position : _localTarget.position,
            Time.deltaTime * _moveSpeed
        );

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _localTarget == null ? _globalTarget.rotation : _localTarget.rotation,
            1
        );
    }
}

using UnityEngine;

public class BlueEnemy : Enemy
{
    void Update()
    {
        CheckLocalTarget();
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            _localTarget ? _localTarget.position : _globalTarget.position,
            Time.deltaTime * _moveSpeed
        );

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _localTarget ? _localTarget.rotation : _globalTarget.rotation,
            1
        );
    }
}

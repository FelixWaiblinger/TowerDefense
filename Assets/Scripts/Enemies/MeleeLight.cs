using UnityEngine;

public class MeleeLight : Enemy
{
    protected override void Attack()
    {
        Debug.Log("Attacking");
        // start attack
        if (_attackTimer == 0)
        {
            // TODO play animation

            var target = _localTarget ? _localTarget : _globalTarget;
            target.gameObject.GetComponentInParent<Structure>().TakeDamage(_attackDamage);

            _attackTimer += Time.deltaTime;
        }
        else
        {
            if (_attackTimer >= 1f / _attackRate) _attackTimer = 0; // reset
            else _attackTimer += Time.deltaTime; // increment
        }
    }
}

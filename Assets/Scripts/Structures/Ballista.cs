using UnityEngine;

public class Ballista : Tower
{
    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void Attack()
    {

    }
}

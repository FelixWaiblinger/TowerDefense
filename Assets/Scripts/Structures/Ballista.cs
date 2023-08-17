using UnityEngine;

public class Ballista : Tower
{
    void Update()
    {
        OnDestruction();

        if (_currentTarget) Attack();
    }
}

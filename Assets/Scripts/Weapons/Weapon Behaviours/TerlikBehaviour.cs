using UnityEngine;

public class TerlikBehaviour : ProjectileWeaponBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.position += direction * currentSpeed * Time.deltaTime;
        }
    }
}

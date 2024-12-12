using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime;
    }
}

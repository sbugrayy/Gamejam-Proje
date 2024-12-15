using UnityEngine;

public class RotatingTerlikBehavior : MonoBehaviour
{
    protected float currentDamage;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage, transform);
        }

        if (col.CompareTag("Boss"))
        {
            BossStats enemy = col.GetComponent<BossStats>();
            enemy.TakeDamage(currentDamage, transform);
        }
    }
}

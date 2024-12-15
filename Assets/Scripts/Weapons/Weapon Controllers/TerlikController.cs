using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TerlikController : WeaponController
{
    private Transform player; // Oyuncu transformu
    private List<Transform> enemies = new List<Transform>(); // Düþmanlarýn listesi
    public Transform target; // Hedef transformu
    protected float currentDamage;

    //Animasyon için
    public Color damageColor = new Color(1, 0, 0, 1);
    public float damageFlashDuration = 0.2f;
    Color Color1;
    SpriteRenderer sr;
    Rigidbody2D rb;
    protected override void Start()
    {
        target = null;

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform; // Oyuncuyu bul
        }
        base.Start();

        InvokeRepeating("TerlikThrow",2f, 1f);
    }

    protected override void Update()
    {
        Vector2 dir = (player.position - transform.position).normalized;

        base.Attack();
    }
    IEnumerator PusbackCooldown(Vector2 dir, float knockbackForce)
    {
        rb.AddForce(dir * -knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(damageFlashDuration);
        rb.linearVelocity = Vector2.zero;

    }
    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = Color1;
    }

    public void TerlikThrow()
    {
        // En yakýn düþmaný bul ve hedef olarak ata
        target = GetClosestEnemy();

        if (target != null)
        {
            // Terliði fýrlatma iþlemi
            GameObject spawnedTerlik = Instantiate(weaponData.Prefab, transform.position, Quaternion.identity);
            spawnedTerlik.GetComponent<TerlikBehaviour>().DirectionChecker((target.position - transform.position).normalized);

            // Zaman gecikmesiyle TakeDamage metodunu Invoke et
            Invoke("Attack", 0.5f); // 0.5 saniye gecikmeyle hasar ver
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Enemy"))
    //    {
    //        EnemyStats enemy = col.GetComponent<EnemyStats>();
    //        enemy.TakeDamage(currentDamage, transform);
    //    }

    //    if (col.CompareTag("Boss"))
    //    {
    //        BossStats enemy = col.GetComponent<BossStats>();
    //        enemy.TakeDamage(currentDamage, transform);
    //    }
    //}


    public void AddEnemy(Transform newEnemy)
    {
        if (!enemies.Contains(newEnemy))
        {
            enemies.Add(newEnemy); // Yeni düþmaný listeye ekle
        }
    }

    Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Düþmanlarý dolaþ ve en yakýn olaný bul
        foreach (Transform enemy in enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(player.position, enemy.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }
}

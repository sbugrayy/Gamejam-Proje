using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TerlikController : WeaponController
{
    private Transform player; // Oyuncu transformu
    private List<Transform> enemies = new List<Transform>(); // Düþmanlarýn listesi
    public Transform target; // Hedef transformu

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
        /////////////////
        Vector2 dir = (player.position - transform.position).normalized;
        /////////////////

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
    /// <summary>
    /// ///////////////////////
    /// </summary>
    public void TerlikThrow()
    {
        // En yakýn düþmaný bul ve hedefi ona ata
        target = GetClosestEnemy();

        if (target != null)
        {
            GameObject spawnedTerlik = Instantiate(weaponData.Prefab, transform.position, Quaternion.identity);
            spawnedTerlik.GetComponent<TerlikBehaviour>().DirectionChecker((target.position - transform.position).normalized);
        }
    }

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

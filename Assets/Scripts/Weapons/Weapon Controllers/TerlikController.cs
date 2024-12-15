using UnityEngine;
using System.Collections.Generic;

public class TerlikController : WeaponController
{
    private Transform player; // Oyuncu transformu
    private List<Transform> enemies = new List<Transform>(); // Düþmanlarýn listesi
    public Transform target; // Hedef transformu

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
        base.Attack();
    }

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

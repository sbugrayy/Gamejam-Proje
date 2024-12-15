using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject FlyPrefab;  // Düþman prefab'ý
    [SerializeField] private float spawnDelay = 10f;  // Spawn gecikme süresi
    private bool hasSpawned = false;  // Spawn durumu kontrolü

    private TerlikController enemyTargeting;  // TerlikController referansý

    void Start()
    {
        // EnemyTargeting referansýný bul
        enemyTargeting = FindObjectOfType<TerlikController>();

        // Spawn iþlemini gecikme süresi sonunda tetikle
        Invoke(nameof(SpawnEnemy), spawnDelay);
    }

    void SpawnEnemy()
    {
        if (!hasSpawned)  // Sadece bir kez spawn et
        {
            GameObject currentEnemy = Instantiate(FlyPrefab, transform.position, Quaternion.identity);

            // Düþmaný TerlikController'a bildir
            if (enemyTargeting != null)
            {
                enemyTargeting.AddEnemy(currentEnemy.transform);
            }

            hasSpawned = true;  // Tekrar spawnlanmasýný engelle
        }
    }
}

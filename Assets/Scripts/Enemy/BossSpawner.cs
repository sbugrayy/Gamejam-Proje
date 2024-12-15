using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject FlyPrefab;  // D��man prefab'�
    [SerializeField] private float spawnDelay = 10f;  // Spawn gecikme s�resi
    private bool hasSpawned = false;  // Spawn durumu kontrol�

    private TerlikController enemyTargeting;  // TerlikController referans�

    void Start()
    {
        // EnemyTargeting referans�n� bul
        enemyTargeting = FindObjectOfType<TerlikController>();

        // Spawn i�lemini gecikme s�resi sonunda tetikle
        Invoke(nameof(SpawnEnemy), spawnDelay);
    }

    void SpawnEnemy()
    {
        if (!hasSpawned)  // Sadece bir kez spawn et
        {
            GameObject currentEnemy = Instantiate(FlyPrefab, transform.position, Quaternion.identity);

            // D��man� TerlikController'a bildir
            if (enemyTargeting != null)
            {
                enemyTargeting.AddEnemy(currentEnemy.transform);
            }

            hasSpawned = true;  // Tekrar spawnlanmas�n� engelle
        }
    }
}

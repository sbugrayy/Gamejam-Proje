using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject FlyPrefab; // Düþman prefab'ý
    [SerializeField]
    private float _minimumTime; // Minumum spawn süresi
    [SerializeField]
    private float _maximumTime; // Maksimum spawn süresi
    private float timeUntilSpawn;

    public GameObject currentEnemy; // Þu anki düþman

    private TerlikController enemyTargeting; // EnemyTargeting referansý

    void Start()
    {
        // EnemyTargeting referansýný bul
        enemyTargeting = FindObjectOfType<TerlikController>();

        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            // Yeni düþman spawn et
            currentEnemy = Instantiate(FlyPrefab, transform.position, Quaternion.identity);

            // Düþmaný EnemyTargeting'e bildir
            enemyTargeting.AddEnemy(currentEnemy.transform);

            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(_minimumTime, _maximumTime);
    }
}

using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject FlyPrefab; // D��man prefab'�
    [SerializeField]
    private float _minimumTime; // Minumum spawn s�resi
    [SerializeField]
    private float _maximumTime; // Maksimum spawn s�resi
    private float timeUntilSpawn;

    public GameObject currentEnemy; // �u anki d��man

    private TerlikController enemyTargeting; // EnemyTargeting referans�

    void Start()
    {
        // EnemyTargeting referans�n� bul
        enemyTargeting = FindObjectOfType<TerlikController>();

        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            // Yeni d��man spawn et
            currentEnemy = Instantiate(FlyPrefab, transform.position, Quaternion.identity);

            // D��man� EnemyTargeting'e bildir
            enemyTargeting.AddEnemy(currentEnemy.transform);

            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(_minimumTime, _maximumTime);
    }
}

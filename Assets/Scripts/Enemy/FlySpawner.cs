using UnityEngine;

public class FlySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject FlyPrefab;
    [SerializeField]
    private float _minimumTime;
    [SerializeField]
    private float _maximumTime;
    private float timeUntilSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame 
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            Instantiate(FlyPrefab, transform.position, Quaternion.identity);
            //Instantiate(FlyPrefab);
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(_minimumTime, _maximumTime);
    }
}
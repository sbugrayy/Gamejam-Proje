using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;
    SpriteRenderer sr;

    void Start()
    {
        player = Object.FindFirstObjectByType<PlayerMovement>().transform;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Düþmaný oyuncuya doðru hareket ettir
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.MoveSpeed * Time.deltaTime);

        // Oyuncunun konumuna göre düþmaný çevir
        if (player.position.x > transform.position.x)
        {
            sr.flipX = true;  // Sol tarafa bak
        }
        else
        {
            sr.flipX = false; // Sað tarafa bak
        }
    }
}

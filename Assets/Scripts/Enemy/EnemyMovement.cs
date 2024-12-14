using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public EnemyScriptableObject enemyData;
    EnemyStats enemy;
    Transform player;
    SpriteRenderer sr;

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = Object.FindFirstObjectByType<PlayerMovement>().transform;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // D��man� oyuncuya do�ru hareket ettir
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemy.currentMoveSpeed * Time.deltaTime);

        // Oyuncunun konumuna g�re d��man� �evir
        if (player.position.x > transform.position.x)
        {
            sr.flipX = true;  // Sol tarafa bak
        }
        else
        {
            sr.flipX = false; // Sa� tarafa bak
        }
    }
}

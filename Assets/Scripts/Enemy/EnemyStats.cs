using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    //Current stats
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;
    //sonradan tanýmladýklarým
    [Header("Damage Feedback")]
    public Color damageColor = new Color(1, 0, 0, 1);
    public float damageFlashDuration = 0.2f;
    public float deathFadeTime = 0.6f;
    Color originalColor;
    SpriteRenderer sr;
    EnemyMovement movement;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }
    public void TakeDamage(float dmg, Transform player, float knockbackForce = 3f, float knockbackDuration = 0.2f)
    {
        currentHealth -= dmg;
        StartCoroutine(DamageFlash());
        Vector2 dir = (player.position - transform.position).normalized;

        rb.AddForce(dir * -knockbackForce, ForceMode2D.Impulse);



        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    //çarpýþma anýnda kýrmýzý parlama metodu
    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = originalColor;
    }
    public void Kill()
    {
        Destroy(gameObject);
    }

    // Çarpýþmayý algýlar
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerStats player = col.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(currentDamage);
                Debug.Log("Player took damage: " + currentDamage);
            }
            else
            {
                Debug.LogError("PlayerStats component not found!");
            }
        }
    }
}

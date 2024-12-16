using System.Collections;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BossStats : MonoBehaviour
{
    public EnemyScriptableObject bossData;

    //Current stats
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;
    //sonradan tan�mlad�klar�m
    [Header("Damage Feedback")]
    public Color damageColor = new Color(1, 0, 0, 1);
    public float damageFlashDuration = 0.2f;
    public float deathFadeTime = 0.6f;
    Color Color1;
    SpriteRenderer sr;
    EnemyMovement movement;
    Rigidbody2D rb;

    [Header("UI")]
    public Image healthBar;
    [Header("events")]
    public UnityEvent customevent;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Color1 = sr.color;
    }
    void Awake()
    {
        currentMoveSpeed = bossData.MoveSpeed;
        currentHealth = bossData.MaxHealth;
        currentDamage = bossData.Damage;
    }
    public void TakeDamage(float dmg, Transform player, float knockbackForce = 3f, float knockbackDuration = 0.2f)
    {
        currentHealth -= dmg;
        StartCoroutine(DamageFlash());
        Vector2 dir = (player.position - transform.position).normalized;
        if (currentHealth <= 0)
        {
            Kill();
        }
        StartCoroutine(PusbackCooldown(dir, knockbackForce));

        UpdateHealthBar();
    }

    // Can bar� g�ncelleniyor
    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / bossData.MaxHealth;
    }
    IEnumerator PusbackCooldown(Vector2 dir, float knockbackForce)
    {
        rb.AddForce(dir * -knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(damageFlashDuration);
        rb.linearVelocity = Vector2.zero;

    }
    //�arp��ma an�nda k�rm�z� parlama metodu
    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = Color1;
    }
    public void Kill()
    {
        customevent.Invoke();
        Destroy(gameObject);
    }

    // �arp��may� alg�lar
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
// PlayerStats.cs
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float health;

    [Header("Damage Cooldown")]
    public float damageCooldown = 1f;
    private bool canTakeDamage = true;

    [Header("Damage Flash")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;      // รูปภาพปกติ
    public Sprite whiteFlashSprite;  // รูปภาพที่เป็นสีขาว (หรือไฟล์ sprite ที่ทำเป็นขาว)

    public int flashCount = 3;
    public float flashInterval = 0.05f;

    private Animator animator;

    void Start()
    {
        health = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if(normalSprite == null && spriteRenderer != null)
        {
            normalSprite = spriteRenderer.sprite; // กำหนดรูปปกติถ้ายังไม่ใส่ใน Inspector
        }
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage) return;

        health -= damage;

        if (spriteRenderer != null && whiteFlashSprite != null)
        {
            StartCoroutine(DamageFlash());
        }

        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamagePrevention());
        }
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);

        if (health > 0)
        {
            canTakeDamage = true;
        }
    }

    private IEnumerator DamageFlash()
    {
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.sprite = whiteFlashSprite;
            yield return new WaitForSeconds(flashInterval);
            spriteRenderer.sprite = normalSprite;
            yield return new WaitForSeconds(flashInterval);
        }
        spriteRenderer.sprite = normalSprite;
    }

    private void Die()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;

        GatherInput input = GetComponentInParent<GatherInput>();
        if (input != null) input.DisableControls();

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        Debug.Log("Player is dead");
    }
}

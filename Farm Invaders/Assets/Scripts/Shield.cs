using UnityEngine;

/// <summary>
/// Controls remaining shield health and destruction when shield is hit by bullets.
/// Change sprites based on amount of health remaining
/// </summary>
public class Shield : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private Sprite[] damageSprites;

    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Init of the sprite rendering as the game starts
    /// </summary>
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Detects collision with bullets and enemy bullets.
    /// </summary>
    /// <param name="collision">The collider that triggered the event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(collision.gameObject);
        }
    }

    /// <summary>
    /// Reduces shield health, updates sprite and destroys it if health reaches zero.
    /// </summary>
    /// <param name="bullet">The bullet GameObject that hit the shield.</param>
    private void TakeDamage(GameObject bullet)
    {
        Destroy(bullet);
        health--;
        UpdateSprite();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Updates shield sprite based on remaining health.
    /// </summary>
    private void UpdateSprite()
    {
        if (health > 0 && health <= damageSprites.Length)
        {
            spriteRenderer.sprite = damageSprites[health - 1];
        }
    }
}
using UnityEngine;

/// <summary>
/// Keeps track of shield health, and destruciton when health hits 0
/// Shields protect the player from enemy bullets.
/// </summary>
public class Shield : MonoBehaviour
{
    [SerializeField] private int health = 3;

    /// <summary>
    /// Detects collision with both Player bullets and Enemy bullets
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
    /// Makes shield take damage from bullets reducing health and destroying the shield when health hits 0
    /// </summary>
    /// <param name="bullet">The bullet GameObject that hit the shield.</param>
    private void TakeDamage(GameObject bullet)
    {
        Destroy(bullet);
        health--;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
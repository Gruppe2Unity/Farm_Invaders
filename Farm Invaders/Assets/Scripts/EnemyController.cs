using UnityEngine;

/// <summary>
/// Controls enemy behavior and handles collision 
/// detection between bullet and enemy
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private int scoreValue = 10;

    /// <summary>
    /// Handles bullets and player trigger collision detection
    /// </summary>
    /// <param name="collision">The collider that triggered the event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HandleBulletHit(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
    }

    /// <summary>
    /// Destroys the bullet and handles what happens when a bullet hits the enemy.
    /// </summary>
    /// <param name="bullet">The bullet GameObject that hit the enemy.</param>
    private void HandleBulletHit(GameObject bullet)
    {
        Destroy(bullet);
        TakeDamage();
    }

    /// <summary>
    /// Handles what happens when enemy hits the player.
    /// </summary>
    private void HandlePlayerCollision()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Destroyes enemy player when health reaches 0
    /// </summary>
    private void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

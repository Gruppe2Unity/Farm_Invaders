using UnityEngine;

/// <summary>
/// Handles player health, player damage and also death
/// Tracks players hit count and keep track of lives
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
     [SerializeField] private GameObject[] hearts;
     [SerializeField] private GameObject gameOverPanel;

    private int currentLives;
    private int hitCount;

    /// <summary>
    /// Init of player lives on game start.
    /// </summary>
    private void Start()
    {
        currentLives = maxLives;
        hitCount = 0;
        UpdateHeartsUI();
    }

    /// <summary>
    /// Detects collision with enemy or enemy bullets.
    /// </summary>
    /// <param name="collision">The collider that triggered the event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(collision.gameObject);
        }
    }

    /// <summary>
    /// Reduces player lives and increments hit count when hit.
    /// </summary>
    /// <param name="source">Gameobject that was shot and hit the player.</param>
    private void TakeDamage(GameObject source)
    {
        hitCount++;
        currentLives--;
        Destroy(source);

        UpdateHeartsUI();

        Debug.Log($"Player hit! Lives remaining: {currentLives} | Total hits: {hitCount}");

        if (currentLives <= 0)
        {
            HandlePlayerDeath();
        }
    }

    
    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentLives);
        }
    }
    
    /// <summary>
    /// Handles player death when all lives are lost.
    /// </summary>
    private void HandlePlayerDeath()
    {
        Debug.Log("Game Over!");
        gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    /// <summary>
    /// Returns current lives for UI display.
    /// </summary>
    public int GetCurrentLives() => currentLives;

    /// <summary>
    /// Returns total hit count for UI display.
    /// </summary>
    public int GetHitCount() => hitCount;
}
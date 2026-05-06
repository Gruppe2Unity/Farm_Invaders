using UnityEngine;
using System.Collections;

/// <summary>
/// Handles player health, player damage and also death.
/// Tracks players hit count and keep track of lives.
/// Handles blinking when player is hit
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject gameOverPanel;

    private SpriteRenderer spriteRenderer;
    private int currentLives;
    private int hitCount;
    private bool isInvincible = false;

    /// <summary>
    /// Init of player lives on game start.
    /// </summary>
    private void Start()
    {
        currentLives = maxLives;
        hitCount = 0;
        UpdateHeartsUI();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Makes player blink when hit to show damage feedback.
    /// </summary>
    private IEnumerator BlinkEffect()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// Detects collision with enemy or enemy bullets.
    /// </summary>
    /// <param name="collision">The collider that triggered the event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible) return;

        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(collision.gameObject);
        }
    }

    /// <summary>
    /// Reduces player lives and increments hit count when hit.
    /// Plays sound and starts blinking when hit
    /// </summary>
    /// <param name="source">Gameobject that was shot and hit the player.</param>
    private void TakeDamage(GameObject source)
    {
        isInvincible = true;
        hitCount++;
        currentLives--;
        Destroy(source);
        UpdateHeartsUI();
        AudioManager.Instance.PlayPlayerHitSound();
        StartCoroutine(BlinkEffect());

        Debug.Log($"Player hit! Lives remaining: {currentLives} | Total hits: {hitCount}");

        if (currentLives <= 0)
        {
            HandlePlayerDeath();
            return;
        }

        Invoke(nameof(ResetInvincibility), 0.5f);
    }

    /// <summary>
    /// Updates heart sprites based on remaining lives.
    /// </summary>
    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentLives);
        }
    }

    /// <summary>
    /// Resets invincibility after a short delay.
    /// </summary>
    private void ResetInvincibility()
    {
        isInvincible = false;
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
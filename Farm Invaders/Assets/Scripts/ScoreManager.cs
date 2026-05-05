using UnityEngine;

/// <summary>
/// Manages the players score and keeps trakc of highscore
/// Uses a singleton instance to allow other scripts to access easy
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int currentScore;
    private int highScore;

    /// <summary>
    /// Initializes the singleton instance and loads highscore.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    /// <summary>
    /// Adds up points accumulated during play to current score and updates highscore if beaten.
    /// </summary>
    /// <param name="points">Amount of points to add.</param>
    public void AddScore(int points)
    {
        currentScore += points;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        Debug.Log($"Score: {currentScore} | Highscore: {highScore}");
    }

    /// <summary>
    /// Resets current score to zero on new game.
    /// </summary>
    public void ResetScore()
    {
        currentScore = 0;
    }

    /// <summary>
    /// Returns current score for UI display.
    /// </summary>
    public int GetCurrentScore() => currentScore;

    /// <summary>
    /// Returns highscore for UI display.
    /// </summary>
    public int GetHighScore() => highScore;
}
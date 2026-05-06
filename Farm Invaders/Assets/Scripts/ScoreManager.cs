using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Displays and manages score and hiscore for the player.
/// Stays working across multiples scenes and "restarts" using singleton pattern
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the ScoreManager.
    /// </summary>
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Finds UI text references and updates them when a new scene loads.
    /// </summary>
    /// <param name="scene">the loaded scene.</param>
    /// <param name="mode">The mode of loaded scene.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScoreText")?.GetComponent<TextMeshProUGUI>();
        ResetScore();
        UpdateUI();
    }

    /// <summary>
    /// "Detaches" from sceneLoaded event when object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Adds points to current score and updates highscore if beaten.
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

        UpdateUI();
        Debug.Log($"Score: {currentScore} | Highscore: {highScore}");
    }

    /// <summary>
    /// Updates score and highscore UI text.
    /// </summary>
    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
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
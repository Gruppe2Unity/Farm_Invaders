using UnityEngine;

/// <summary>
/// Manages levels of the game and increases diffculty per level defeated
/// Spawns new enemy formations when all enemies are defeated.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private GameObject enemyFormationPrefab;
    [SerializeField] private float speedIncreasePerLevel = 0.5f;
    [SerializeField] private TMPro.TextMeshProUGUI levelText;


    private int currentLevel = 1;
    private EnemyFormation activeFormation;

    /// <summary>
    /// Updates the level on the display
    /// </summary>
    private void UpdateLevelDisplay()
    {
        if (levelText != null)
        {
            levelText.text = $"Level: {currentLevel}";
        }
    }

    /// <summary>
    /// Initializes the singleton instance to make access easier
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// When the game begins the first level starts
    /// </summary>
    private void Start()
    {
        UpdateLevelDisplay();
        SpawnFormation();
    }

    /// <summary>
    /// Game loop, updates every frame and checks if all enemies are defeated
    /// </summary>
    private void Update()
    {
        if (activeFormation != null && activeFormation.IsEmpty())
        {
            NextLevel();
        }
    }

    /// <summary>
    /// Advances to the next level and increases enemy speed.
    /// </summary>
    private void NextLevel()
    {
        currentLevel++;
        Debug.Log($"Level {currentLevel}!");
        UpdateLevelDisplay();
        SpawnFormation();
    }

    /// <summary>
    /// Spawns a new enemy formation with increasted speed after the previous is defeated 
    /// </summary>
    private void SpawnFormation()
    {
        GameObject formation = Instantiate(enemyFormationPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        activeFormation = formation.GetComponent<EnemyFormation>();
        activeFormation.SetSpeed(1f + (currentLevel - 1) * speedIncreasePerLevel);
    }

    /// <summary>
    /// Returns the current level number.
    /// </summary>
    public int GetCurrentLevel() => currentLevel;


}

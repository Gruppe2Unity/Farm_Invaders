using UnityEngine;
using UnityEngine.SceneManagement;

    /// <summary>
    /// Handles the game over screen and the buttons restart and main menu
    /// </summary>

public class GameOverManager : MonoBehaviour
{
    

    /// <summary>
    /// Restarts the game again.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f; // Skru på spillet igjen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Handles going back to the menu after clicking "back to menu"
    /// </summary>
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
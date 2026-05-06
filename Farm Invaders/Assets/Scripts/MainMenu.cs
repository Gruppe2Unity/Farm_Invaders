using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles interactions with the main menu button.
/// Controls scene loading and application exit.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the GameScene when play button is pressed.
    /// </summary>
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// When the quit button is pressed the application is closed.
    /// </summary>
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles interactions with the main menu buttons. Handles interaction with how to play button
/// Controls scene loading and application exit.
/// </summary>
public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject howToPlayPanel;

    /// <summary>
    /// Shows or hides the How To Play panel.
    /// </summary>
    public void OnHowToPlayButtonPressed()
    {
        howToPlayPanel.SetActive(!howToPlayPanel.activeSelf);
    }

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
using UnityEngine;

/// <summary>
/// Manages all game audio including sound effects and background music.
/// Uses singleton pattern for easy access from other scripts.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip enemyDeathSound;
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    /// <summary>
    /// Initializes singleton and audio sources on awake.
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

        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.5f;
        musicSource.Play();
    }

    /// <summary>
    /// Plays the shoot sound effect.
    /// </summary>
    public void PlayShootSound()
    {
        sfxSource.PlayOneShot(shootSound);
    }

    /// <summary>
    /// Plays the enemy death sound effect.
    /// </summary>
    public void PlayEnemyDeathSound()
    {
        sfxSource.PlayOneShot(enemyDeathSound);
    }

    /// <summary>
    /// Plays the player hit sound effect.
    /// </summary>
    public void PlayPlayerHitSound()
    {
        sfxSource.PlayOneShot(playerHitSound);
    }
}
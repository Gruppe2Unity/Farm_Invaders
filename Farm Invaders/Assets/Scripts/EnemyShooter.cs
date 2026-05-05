using UnityEngine;

/// <summary>
/// Handles enemy shooting.
/// Randomly shoots bullets downwards toward the player.
/// </summary>
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private float minFireRate = 1f;
    [SerializeField] private float maxFireRate = 3f;

    private float nextFireTime;

    /// <summary>
    /// Makes the first fire time start randomly.
    /// </summary>
    private void Start()
    {
        nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
    }

    /// <summary>
    /// Game loop, updates every frame and checks if enemy should shoot.
    /// </summary>
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    /// <summary>
    /// Shoots a bullet and sets next fire time randomly.
    /// </summary>
    private void Shoot()
    {
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
    }
}
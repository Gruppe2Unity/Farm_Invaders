using UnityEngine;

/// <summary>
/// Handles enemy bullet movement and destroys it when it goes off the screen.
/// </summary>
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;

    /// <summary>
    /// Game loop, updates every frame and moves the bullet downward.
    /// </summary>
    private void Update()
    {
        MoveBullet();
        DestroyIfOffScreen();
    }

    /// <summary>
    /// Moves bullet at constant speed downward.
    /// </summary>
    private void MoveBullet()
    {
        transform.position += Vector3.down * bulletSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Destroys bullet when it goes off the screen.
    /// </summary>
    private void DestroyIfOffScreen()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
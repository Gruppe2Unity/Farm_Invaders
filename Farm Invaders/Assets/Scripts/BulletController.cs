using UnityEngine;

/// <summary>
/// Controls bullets that are shot and destroys them when they go offscreen.
/// </summary>
public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;


    /// <summary>
    /// Game loop - moves bullets upward each frame, updating the changes in MoveBullet
    /// </summary>
    private void Update()
    {
        MoveBullet();
        DestroyIfOffScreen();
    }

    /// <summary>
    /// Moves bullets upward at a constant speed
    /// </summary>
    private void MoveBullet()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
    }


    /// <summary>
    /// Destroys bullets that go off-screen.
    /// </summary>

    private void DestroyIfOffScreen()
    {
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
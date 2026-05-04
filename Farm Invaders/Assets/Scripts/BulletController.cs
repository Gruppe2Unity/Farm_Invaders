using UnityEngine;

/// <summary>
/// kontroller kuler som skytes og sletter det når de kommer "offscreen"
/// </summary>
public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;


    /// <summary>
    /// Game loop - beveger kuler oppover hver frame, oppdaterer endringene i movebullet
    /// </summary>
    private void Update()
    {
        MoveBullet();
        DestroyIfOffScreen();
    }

    /// <summary>
    /// beveger kuler oppover med konstant fart
    /// </summary>
    private void MoveBullet()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
    }


    /// <summary>
    /// ødelegger kuler som går ut av bildet.
    /// </summary>

    private void DestroyIfOffScreen()
    {
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
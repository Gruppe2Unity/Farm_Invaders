using UnityEngine;

/// <summary>
/// Controls the movement of the enemy formation.
/// Moves enemies side to side and downward when reaching screen edges.
/// </summary>
public class EnemyFormation : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float stepDown = 0.5f;
    [SerializeField] private float edgeLimit = 4f;

    private float moveDirection = 1f;
    private bool shouldStepDown = false;

    /// <summary>
    /// Game loop - moves the formation every frame.
    /// </summary>
    private void Update()
    {
        MoveFormation();

        if (shouldStepDown)
        {
            StepDown();
        }
    }

    /// <summary>
    /// Moves the formation horizontally and checks screen edges.
    /// </summary>
    private void MoveFormation()
    {
        transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.x >= edgeLimit || transform.position.x <= -edgeLimit)
        {
            moveDirection *= -1f;
            shouldStepDown = true;

            // Clamp position so enemies don't go past edge
            float clampedX = Mathf.Clamp(transform.position.x, -edgeLimit, edgeLimit);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    /// <summary>
    /// Moves the formation downward one step.
    /// </summary>
    /// <summary>
    /// Moves the formation downward one fixed step.
    /// </summary>
    private void StepDown()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - stepDown,
            transform.position.z
        );
        shouldStepDown = false;
    }
    /// <summary>
    /// Sets the movement speed of the formation.
    /// </summary>
    /// <param name="speed">New movement speed.</param>
    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    /// <summary>
    /// Checks if all enemies in the formation are dead.
    /// </summary>
    public bool IsEmpty()
    {
        return transform.childCount == 0;
    }
}